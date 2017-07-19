package jp.co.isid.ham.media.model;

import jp.co.isid.ham.common.model.Tbj01MediaPlanCondition;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

public class FindTimeExcelImportManager {

    /** シングルトンインスタンス */
    private static FindTimeExcelImportManager _manager = new FindTimeExcelImportManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindTimeExcelImportManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindTimeExcelImportManager getInstance() {
        return _manager;
    }


    public FindTimeExcelImportResult findTimeExcelImport(FindTimeExcelImportCondition cond)
            throws HAMException {

        //検索結果
        FindTimeExcelImportResult result = new FindTimeExcelImportResult();

        // ******************************************************
        // 媒体状況管理データ取得
        // ******************************************************
        Tbj01MediaPlanDAO mpdao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        Tbj01MediaPlanCondition mpcond = new Tbj01MediaPlanCondition();
        mpcond.setMediacd(cond.getMediaCd());
        result.setMediaPlan(mpdao.findMediaPlanByMediaCd(mpcond,cond.getKikanFrom(),cond.getKikanTo()));

        // ******************************************************
        // 排他チェックのため、営業作業台帳データ取得
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
