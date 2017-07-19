package jp.co.isid.ham.media.model;

import java.util.List;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu14ThsTntTrCondition;
import jp.co.isid.ham.common.model.RepaVbjaMeu14ThsTntTrDAO;
import jp.co.isid.ham.common.model.RepaVbjaMeu14ThsTntTrDAOFactory;
import jp.co.isid.ham.common.model.RepaVbjaMeu14ThsTntTrVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcCondition;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcDAO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcDAOFactory;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcVO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindCooperationDataManager {

    /** �V���O���g���C���X�^���X */
    private static FindCooperationDataManager _manager = new FindCooperationDataManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindCooperationDataManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindCooperationDataManager getInstance() {
        return _manager;
    }

    /**
     * DKB�A�g�p�f�[�^���������܂�
     *
     * @return FindCooperationDataResult DKB�A�g�p�f�[�^
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public FindCooperationDataResult findCooperationData(FindCooperationDataCondition cond)
            throws HAMException {

        //��������
        FindCooperationDataResult result = new FindCooperationDataResult();

        String items = "'�f�ڗ�','�F����','�w�藿','��A�ŗ�','�g�֗�','�ό`�X�y�[�X��','�X�v���b�g������'";
        String itemCd = null;
        String codetype = "'26','27','28','29','30'";

        // ******************************************************
        // �������̎擾
        // ******************************************************
        RepaVbjaMeu14ThsTntTrDAO chargedao = RepaVbjaMeu14ThsTntTrDAOFactory.createRepaVbjaMeu14ThsTntTrDAO();
        RepaVbjaMeu14ThsTntTrCondition chargecond = new RepaVbjaMeu14ThsTntTrCondition();
        chargecond.setEgsyocd("10");
        chargecond.setThskgycd("382743");
        chargecond.setSeqno("06");
        chargecond.setTrtntseqno("04");
        List<RepaVbjaMeu14ThsTntTrVO> chargelist = chargedao.findCharge(chargecond,cond.getEigyobi(),cond.getEigyobi());
        //������񂪌�����Ȃ�������ꊪ�̏I���
        if (chargelist.size() == 0) {
            throw new HAMException("����","BJ-E0002");
        }

        result.setRepaVbjaMeu14ThsTntTr(chargelist);

        // ******************************************************
        // ��ڏ��̎擾(��ڂ͕K�v�Ȃ��̂�S������Ă����Ⴄ)
        // ******************************************************
        //�V���̋Ɩ��敪���擾
        RepaVbjaMeu29CcDAO gyomudao = RepaVbjaMeu29CcDAOFactory.createRepaVbjaMeu29CcDAO();
        List<RepaVbjaMeu29CcVO> gyomulist = gyomudao.FindCodeMasterByCode("'87'", "�V��");
        RepaVbjaMeu29CcVO gyomuVO = gyomulist.get(0);

        FindItemDAO itemdao = FindCooperationDataDAOFactory.createFindItemDAO();
        FindItemCondition itemcond = new FindItemCondition();
        itemcond.setItems(items);
        itemcond.setKikanFrom(cond.getEigyobi());
        itemcond.setKikanTo(cond.getEigyobi());
        itemcond.setWorkFlg(gyomuVO.getKYCD());
        List<FindItemVO> itemlist = itemdao.findItem(itemcond);
        result.setItem(itemlist);

        //�X�y�[�X(�X�y�[�X�̃J�����ɓ��͉\�Ȓl�Ƃ��̃R�[�h)���擾
        RepaVbjaMeu29CcCondition spaceCond = new RepaVbjaMeu29CcCondition();
        spaceCond.setKycdknd("WE");
        result.setSpace(gyomudao.selectVO(spaceCond));

        for (FindItemVO itemvo : itemlist) {
            itemCd = itemCd + itemvo.getHMOKCD();
        }

        // ******************************************************
        // HAM�̃R�[�h�}�X�^���擾
        // ******************************************************
        Mbj12CodeDAO codedao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codecond = new Mbj12CodeCondition();
        codecond.setCodetype(codetype);
        List<Mbj12CodeVO> codelist = codedao.FindManyCd(codecond);
        result.setMbj12Code(codelist);

        //�c�ƍ�Ƒ䒠�f�[�^�ɑ΂���f�[�^���擾
        List<FindSocietyDataVO> societylist = null;
        for (Tbj02EigyoDaichoVO getvo:cond.getTbj02EigyoDaicho())
        {
            // ******************************************************
            // �g�D�����擾
            // ******************************************************
            FindSocietyDataDAO societydao = FindCooperationDataDAOFactory.createFindSocietyDataDAO();
            FindSocietyDataCondition societycond = new FindSocietyDataCondition();
            societycond.setRequestDestination(getvo.getREQUESTDESTINATION());
            societycond.setKikanFrom(cond.getEigyobi());
            societycond.setKikanTo(cond.getEigyobi());
            societycond.setDaichoNo(getvo.getDAICHONO());
            List<FindSocietyDataVO> getsocietylist = societydao.findSocietyData(societycond);
            if (societylist == null)
            {
                societylist = getsocietylist;
            }
            else
            {
                societylist.addAll(getsocietylist);
            }
        }

        result.setSocietyData(societylist);

        return result;
    }
}
