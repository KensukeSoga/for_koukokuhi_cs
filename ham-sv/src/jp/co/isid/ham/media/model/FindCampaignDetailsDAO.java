package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Tbj13CampDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

/**
 *
 * <P>
 * �L�����y�[���ꗗ�̏��擾DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class FindCampaignDetailsDAO extends AbstractRdbDao {


    /** �f�[�^�������� */
    private FindCampaignDetailsCondition _cond;


    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindCampaignDetailsDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }


    /**
     * �v���C�}���L�[��Ԃ��܂�
     *
     * @return String[] �v���C�}���L�[
     */
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �X�V���t�t�B�[���h��Ԃ��܂�
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        // new String[] {};
        return null;
    }

    /**
     * �e�[�u������Ԃ��܂�
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj13CampDetail.TBNAME;
    }

    /**
     * �e�[�u���񖼂�Ԃ��܂�
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        return getCampaignList();
    }

    /**
     * �L�����y�[���ꗗ��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    private String getCampaignList()
    {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" * ");
        sql.append(" FROM ");
        sql.append(" "+ getTableName() + ", ");
        sql.append(" "+ Mbj03Media.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj13CampDetail.MEDIACD + "= " + Mbj03Media.MEDIACD + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj13CampDetail.CAMPCD+ "= '" + _cond.getCampaignNo() + "' ");
        sql.append(" ORDER BY ");
        sql.append(" " + Mbj03Media.SORTNO + ", ");
        sql.append(" " + Tbj13CampDetail.KIKANFROM+ " ");


        return sql.toString();
    }


    /**
     * �L�����y�[���ꗗ�̌������s���܂�
     *
     * @return �L�����y�[���ꗗVO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<FindCampaignDetailstVO> findCampaignListByCond(
            FindCampaignDetailsCondition cond) throws HAMException {

        super.setModel(new FindCampaignDetailstVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "E0002");
        }
    }

    /**
     * Model�̐������s��<br>
     * �������ʂ�VO��KEY���啶���̂��ߕϊ��������s��<br>
     * AbstractRdbDao��createFindedModelInstances���I�[�o�[���C�h<br>
     *
     * @param hashList
     *            List ��������
     * @return List<FindJissiNoCntCondVO> �ϊ���̌�������
     */
    @Override
    protected List<FindCampaignDetailstVO> createFindedModelInstances(List hashList) {

        List<FindCampaignDetailstVO> list = new ArrayList<FindCampaignDetailstVO>();

        if (getModel() instanceof FindCampaignDetailstVO) {

            for (int i = 0; i < hashList.size(); i++) {

                Map result = (Map) hashList.get(i);
                FindCampaignDetailstVO vo = new FindCampaignDetailstVO();

                vo.setCAMPCD((String)result.get(Tbj13CampDetail.CAMPCD.toUpperCase()));
                vo.setDCARCD((String)result.get(Tbj13CampDetail.DCARCD.toUpperCase()));
                vo.setMEDIACD((String)result.get(Tbj13CampDetail.MEDIACD.toUpperCase()));
                vo.setPHASE((BigDecimal)result.get(Tbj13CampDetail.PHASE.toUpperCase()));
                vo.setYOTEIYM((Date)result.get(Tbj13CampDetail.YOTEIYM.toUpperCase()));
                vo.setKIKANFROM((Date)result.get(Tbj13CampDetail.KIKANFROM.toUpperCase()));
                vo.setKIKANTO((Date)result.get(Tbj13CampDetail.KIKANTO.toUpperCase()));
                vo.setBUDGET((BigDecimal)result.get(Tbj13CampDetail.BUDGET.toUpperCase()));
                vo.setBUDGETHM((BigDecimal)result.get(Tbj13CampDetail.BUDGETHM.toUpperCase()));
                vo.setCRTDATE((Date)result.get(Tbj13CampDetail.CRTDATE.toUpperCase()));
                vo.setCRTNM((String)result.get(Tbj13CampDetail.CRTNM.toUpperCase()));
                vo.setCRTAPL((String)result.get(Tbj13CampDetail.CRTAPL.toUpperCase()));
                vo.setCRTID((String)result.get(Tbj13CampDetail.CRTID.toUpperCase()));
                vo.setUPDDATE((Date)result.get(Tbj13CampDetail.UPDDATE.toUpperCase()));
                vo.setUPDNM((String)result.get(Tbj13CampDetail.UPDNM.toUpperCase()));
                vo.setUPDAPL((String)result.get(Tbj13CampDetail.UPDAPL.toUpperCase()));
                vo.setUPDID((String)result.get(Tbj13CampDetail.UPDID.toUpperCase()));
                vo.setMEDIANM((String)result.get(Mbj03Media.MEDIANM.toUpperCase()));
                vo.setHCMEDIANM((String)result.get(Mbj03Media.HCMEDIANM.toUpperCase()));
                vo.setDNEBIKI((BigDecimal)result.get(Mbj03Media.DNEBIKI.toUpperCase()));
                vo.setSORTNO((BigDecimal)result.get(Mbj03Media.SORTNO.toUpperCase()));
                vo.setMEDIAUPDDATE((Date)result.get(Mbj03Media.UPDDATE.toUpperCase()));


                // �������ʒ���̏�Ԃɂ���
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }
        return list;
    }

}