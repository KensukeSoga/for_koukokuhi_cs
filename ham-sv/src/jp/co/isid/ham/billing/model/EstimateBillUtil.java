package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj26BillGroupDAO;
import jp.co.isid.ham.common.model.Mbj26BillGroupDAOFactory;
import jp.co.isid.ham.common.model.Mbj26BillGroupVO;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailCondition;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailDAO;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailDAOFactory;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * ���Ϗ��E�������Ɋւ��郆�[�e�B���e�B�N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/09/11 HLC S.Fujimoto)<BR>
 * �E�����Ɩ��ύX�Ή�(2016/02/04 HLC K.Soga)<BR>
 * �EHDX�Ή�(2016/04/20 HLC K.Soga)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class EstimateBillUtil {

    /**
     * HC����R�[�h(Fee�Č������p)�擾
     * MAP�i�[�p
     * @return ��������
     * @throws HAMException
     */
    public static List<Mbj26BillGroupVO> getHCBumonCdBillList(String groupCd) throws HAMException {

        Mbj26BillGroupDAO mbj26Dao = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();
        List<Mbj26BillGroupVO> voList = new ArrayList<Mbj26BillGroupVO>();
        voList = mbj26Dao.selectBillGroupVO(groupCd);

        return voList;
    }

    /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga ADD Start */
    /**
     * HC����R�[�h(Fee�Č������p)�擾
     * @return ��������
     * @throws HAMException
     */
    public static List<Mbj26BillGroupVO> getBillList(String groupCd) throws HAMException {

        //�����O���[�v�}�X�^
        Mbj26BillGroupDAO mbj26Dao = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();
        List<Mbj26BillGroupVO> voList = new ArrayList<Mbj26BillGroupVO>();
        voList = mbj26Dao.selectHCBumonBillGroupVO(groupCd);

        return voList;
    }
    /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga ADD End */

    /**
     * HM������(���ϖ��׏o�͏�SEQNO)�W�v�L�[�擾
     * @param condition ��������
     * @return ��������
     * @throws HAMException
     */
    public static List<FindHMBillSeqNoVO> getHMBillSeqNoSummary(FindHMBillSeqNoCondition condition) throws HAMException {

        //HM������(���ϖ��׏o�͏�SEQNO)�擾����DAO
        FindHMBillSeqNoDAO dao = FindHCEstimateCreationDAOFactory.createFindHMBillDetailSeqNoDao();
        FindHMBillSeqNoCondition cond = new FindHMBillSeqNoCondition();

        cond.setPhase(condition.getPhase());
        cond.setYearMonth(condition.getYearMonth());

        /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga ADD Start */
        cond.setGroupCd(condition.getGroupCd());
        cond.setHcbumoncdbill(condition.getHcbumoncdbill());
        //����
        if(cond.getGroupCd() != null){
            cond.setGroupCd(condition.getGroupCd());
        //�}��
        }else{
            cond.setGroupCd(HAMConstants.GROUPCODE0);
        }
        /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga ADD End */

        return dao.selectSummaryVO(cond);
    }

    /**
     * ������O���[�v�o�͏�SEQNO�X�V
     * @param voList List<FindHMBillSeqNoVO> HM������(���ϖ��׏o�͏�SEQNO)�W�v�L�[
     * @param map HashMap<String, BigDecimal> �����O���[�v�}�b�v
     * @return ����I��(true)/�ُ�I��(false)
     * @throws HAMException
     */
    public static boolean updateHCBumonCdBill(List<FindHMBillSeqNoVO> voList, HashMap<String, BigDecimal> map, BigDecimal estSeqNo, String mediaProduction) throws HAMException {

        //SEQNO�����ݒ�
        BigDecimal seqNo = BigDecimal.valueOf(0);

        try {
            //SeqNo����ő�l���擾
            for (int i = 0; i < voList.size(); i++) {

                //1�s�擾
                FindHMBillSeqNoVO vo = voList.get(i);

                //������O���[�v��Null�łȂ��ꍇ
                if (vo.getHCBUMONCDBILL() != null && vo.getHCBUMONCDBILL().trim().length() != 0 &&
                        vo.getMBJ26HCBUMONCDBILL() != null && vo.getMBJ26HCBUMONCDBILL().trim().length() != 0) {

                    //�����O���[�v�}�b�v���̍ő�l���傫���ꍇ�Ɋi�[
                    if (map.get(vo.getHCBUMONCDBILL()).compareTo(vo.getHCBUMONCDBILLSEQNO()) < 0) {
                        map.put(vo.getHCBUMONCDBILL(), vo.getHCBUMONCDBILLSEQNO());
                    }
                }
            }

            //SeqNo�t�^
            for (int i = 0; i < voList.size(); i++) {

                /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga ADD Start */
                //����SEQNO������̏ꍇ
                if(voList.get(i).getESTSEQNO().equals(estSeqNo)){
                /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga ADD End */

                    //1�s�擾
                    FindHMBillSeqNoVO vo = voList.get(i);

                    //���ώ�ʂ��}�́A�o�̓O���[�v��1���ڂ�[1]�̏ꍇ
                    if(mediaProduction.equals(HAMConstants.MEDIA) && vo.getOUTPUTGROUP().substring(0, 1).equals(HAMConstants.ONE)){
                        //�擾����VO�ŁA������O���[�v�}�X�^�̐�����O���[�v���擾
                        seqNo = map.get(vo.getMBJ26HCBUMONCDBILL());

                        //������O���[�v��Null�̏ꍇ
                        if (vo.getHCBUMONCDBILL() == null || vo.getHCBUMONCDBILL().trim().length() == 0) {
                            vo.setHCBUMONCDBILL(vo.getMBJ26HCBUMONCDBILL());
                            vo.setUPDATEFLG(BigDecimal.valueOf(1));
                            vo.setHCBUMONCDBILLSEQNO(seqNo.add(BigDecimal.valueOf(1)));
                            map.put(vo.getMBJ26HCBUMONCDBILL(), seqNo.add(BigDecimal.valueOf(1)));

                            /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga DEL Start */
                            //map.put(vo.getMBJ26HCBUMONCDBILL(), seqNo.add(BigDecimal.valueOf(1)));
                            /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga DEL End */

                            //������O���[�v��Null�łȂ��ꍇ
                        } else {

                            //���ϖ��ׂ̐�����O���[�v��������O���[�v�}�X�^�̐�����O���[�v�̏ꍇ
                            if (!vo.getHCBUMONCDBILL().equals(vo.getMBJ26HCBUMONCDBILL())) {
                                vo.setHCBUMONCDBILL(vo.getMBJ26HCBUMONCDBILL());
                                vo.setHCBUMONCDBILLSEQNO(seqNo.add(BigDecimal.valueOf(1)));
                                map.put(vo.getMBJ26HCBUMONCDBILL(), seqNo.add(BigDecimal.valueOf(1)));
                            }
                        }
                    }

                    /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga ADD Start */
                    //���ώ�ʂ�����̏ꍇ
                    if(mediaProduction.equals(HAMConstants.PRODUCTION)){

                        //�����ݒ�
                        Boolean flg = false;

                        //�擾����VO�ŁA������O���[�v�}�X�^�̐�����O���[�v���擾
                        seqNo = map.get(vo.getMBJ26HCBUMONCDBILL());

                        //������O���[�v��Null�̏ꍇ
                        vo.setUPDATEFLG(BigDecimal.valueOf(1));
                        vo.setESTDETAILSEQNO(voList.get(i).getESTDETAILSEQNO());
                        vo.setOUTPUTGROUP(voList.get(i).getOUTPUTGROUP());

                        //���ɑ��݂���o�̓O���[�v������ꍇ�A���̏o�̓O���[�v��ݒ�
                        for (int j = 0; j < voList.size(); j++) {
                            if(i != 0 && voList.get(i).getOUTPUTGROUP().equals(voList.get(j).getOUTPUTGROUP())
                                    && !(voList.get(i).getESTDETAILSEQNO() == voList.get(j).getESTDETAILSEQNO())
                                    && voList.get(j).getUPDATEFLG() == BigDecimal.valueOf(1)){
                                //�擾����VO�ŁA������O���[�v�}�X�^�̐�����O���[�v���擾
                                vo.setHCBUMONCDBILL(vo.getMBJ26HCBUMONCDBILL());
                                vo.setHCBUMONCDBILLSEQNO(voList.get(j).getHCBUMONCDBILLSEQNO());
                                flg = true;
                            }
                        }
                        if(!flg && (vo.getHCBUMONCDBILL() == null || vo.getHCBUMONCDBILL().trim().length() == 0))
                        {
                            vo.setHCBUMONCDBILL(vo.getMBJ26HCBUMONCDBILL());
                            vo.setHCBUMONCDBILLSEQNO(seqNo.add(BigDecimal.valueOf(1)));
                            map.put(vo.getMBJ26HCBUMONCDBILL(), seqNo.add(BigDecimal.valueOf(1)));
                        }
                    /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga ADD End */
                    }
                }
            }

            //���ϖ��׍X�V
            Tbj06EstimateDetailDAO tbj06Dao = Tbj06EstimateDetailDAOFactory.createTbj06EstimateDetailDAO();
            Tbj06EstimateDetailCondition tbj06Cond = new Tbj06EstimateDetailCondition();

            //�擾�������ϖ��ו����[�v����
            for (int i = 0; i < voList.size(); i++) {
                FindHMBillSeqNoVO vo = voList.get(i);

                //�}�̂̏ꍇ
                if(mediaProduction.equals(HAMConstants.MEDIA) && vo.getOUTPUTGROUP().substring(0, 1).equals(HAMConstants.ONE)){
                    //�X�V�t���O��[1]�A�o�̓O���[�v�R�[�h��null�̏ꍇ
                    if(vo.getUPDATEFLG().equals(BigDecimal.valueOf(1))) {
                        tbj06Cond.setPhase(vo.getPHASE());
                        tbj06Cond.setCrdate(vo.getCRDATE());
                        tbj06Cond.setEstseqno(vo.getESTSEQNO());
                        tbj06Cond.setOutputgroup(vo.getOUTPUTGROUP());

                        /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga MOD Start */
                        //List<Tbj06EstimateDetailVO> tbj06VoList = tbj06Dao.selectVO(tbj06Cond);
                        List<Tbj06EstimateDetailVO> tbj06VoList = tbj06Dao.findBillSeqNoVO(tbj06Cond);
                        /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga MOD End */

                        //���ϖ��׌��������[�v����
                        for (int j = 0; j < tbj06VoList.size(); j++) {
                            Tbj06EstimateDetailVO tbj06SelectVo = tbj06VoList.get(j);

                            //�X�V
                            Tbj06EstimateDetailVO tbj06Vo = new Tbj06EstimateDetailVO();
                            tbj06Vo.setESTDETAILSEQNO(tbj06SelectVo.getESTDETAILSEQNO());
                            tbj06Vo.setHCBUMONCDBILL(vo.getHCBUMONCDBILL());
                            tbj06Vo.setHCBUMONCDBILLSEQNO(vo.getHCBUMONCDBILLSEQNO());
                            tbj06Vo.setCRTDATE(tbj06SelectVo.getCRDATE());
                            tbj06Vo.setCRTNM(tbj06SelectVo.getCRTNM());
                            tbj06Vo.setCRTAPL(tbj06SelectVo.getCRTAPL());
                            tbj06Vo.setCRTID(tbj06SelectVo.getCRTID());
                            tbj06Vo.setUPDNM(tbj06SelectVo.getUPDNM());
                            tbj06Vo.setUPDAPL(tbj06SelectVo.getUPDAPL());
                            tbj06Vo.setUPDID(tbj06SelectVo.getUPDID());
                            tbj06Dao.updateVO(tbj06Vo);
                        }
                    }
                }

                /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga ADD Start */
                //����̏ꍇ
                if(mediaProduction.equals(HAMConstants.PRODUCTION) ){
                    //�X�V�t���O��[1]�̏ꍇ
                    if(vo.getUPDATEFLG() == BigDecimal.valueOf(1)) {
                        tbj06Cond.setPhase(vo.getPHASE());
                        tbj06Cond.setCrdate(vo.getCRDATE());
                        tbj06Cond.setEstseqno(vo.getESTSEQNO());
                        tbj06Cond.setOutputgroup(vo.getOUTPUTGROUP());
                        List<Tbj06EstimateDetailVO> tbj06VoList = tbj06Dao.findBillSeqNoVO(tbj06Cond);

                        //���ϖ��׌��������[�v����
                        for (int j = 0; j < tbj06VoList.size(); j++) {
                            Tbj06EstimateDetailVO tbj06SelectVo = tbj06VoList.get(j);

                            //���ϖ��׊Ǘ�NO�����l�̏ꍇ
                            if(tbj06SelectVo.getESTDETAILSEQNO().equals(vo.getESTDETAILSEQNO())){
                                //�X�V
                                Tbj06EstimateDetailVO tbj06Vo = new Tbj06EstimateDetailVO();
                                tbj06Vo.setESTDETAILSEQNO(tbj06SelectVo.getESTDETAILSEQNO());
                                tbj06Vo.setHCBUMONCDBILL(vo.getHCBUMONCDBILL());
                                tbj06Vo.setHCBUMONCDBILLSEQNO(vo.getHCBUMONCDBILLSEQNO());
                                tbj06Vo.setCRTDATE(tbj06SelectVo.getCRDATE());
                                tbj06Vo.setCRTNM(tbj06SelectVo.getCRTNM());
                                tbj06Vo.setCRTAPL(tbj06SelectVo.getCRTAPL());
                                tbj06Vo.setCRTID(tbj06SelectVo.getCRTID());
                                tbj06Vo.setUPDNM(tbj06SelectVo.getUPDNM());
                                tbj06Vo.setUPDAPL(tbj06SelectVo.getUPDAPL());
                                tbj06Vo.setUPDID(tbj06SelectVo.getUPDID());
                                tbj06Dao.updateVO(tbj06Vo);
                            }
                        }
                    }
                /** 2016/02/04 �����Ɩ��ύX�Ή� HLC K.Soga ADD End */
                }
            }
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }

        return true;
    }
}
