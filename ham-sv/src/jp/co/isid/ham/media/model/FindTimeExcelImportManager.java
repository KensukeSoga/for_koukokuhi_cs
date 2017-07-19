package jp.co.isid.ham.media.model;

import jp.co.isid.ham.common.model.Tbj01MediaPlanCondition;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

public class FindTimeExcelImportManager {

    /** �V���O���g���C���X�^���X */
    private static FindTimeExcelImportManager _manager = new FindTimeExcelImportManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindTimeExcelImportManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindTimeExcelImportManager getInstance() {
        return _manager;
    }


    public FindTimeExcelImportResult findTimeExcelImport(FindTimeExcelImportCondition cond)
            throws HAMException {

        //��������
        FindTimeExcelImportResult result = new FindTimeExcelImportResult();

        // ******************************************************
        // �}�̏󋵊Ǘ��f�[�^�擾
        // ******************************************************
        Tbj01MediaPlanDAO mpdao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        Tbj01MediaPlanCondition mpcond = new Tbj01MediaPlanCondition();
        mpcond.setMediacd(cond.getMediaCd());
        result.setMediaPlan(mpdao.findMediaPlanByMediaCd(mpcond,cond.getKikanFrom(),cond.getKikanTo()));

        // ******************************************************
        // �r���`�F�b�N�̂��߁A�c�ƍ�Ƒ䒠�f�[�^�擾
        // ******************************************************
        FindAuthorityAccountBookDAO acdao = FindAuthorityAccountBookDAOFactory.createFindAuthorityAccountBookDAO();
        FindAuthorityAccountBookCondition accond = new FindAuthorityAccountBookCondition();
        accond.setKikanFrom(cond.getKikanFrom());
        accond.setKikanTo(cond.getKikanTo());
        accond.setHamid(cond.getHamid());
        accond.setMediaCd("");
        accond.setDCarCd("");
        accond.setMediasNm("");
        accond.setCampNm("");
        result.setAccountBook(acdao.findAuthorityAccountBookByCond(accond));

        return result;
    }
}
