package jp.co.isid.ham.production.model;


import java.text.ParseException;
import java.text.SimpleDateFormat;

import jp.co.isid.ham.common.model.Mbj52SzTntUserCondition;
import jp.co.isid.ham.common.model.Mbj52SzTntUserDAO;
import jp.co.isid.ham.common.model.Mbj52SzTntUserDAOFactory;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOACondition;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOADAO;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOADAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * TVCM素材一覧検索Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/03/09 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
public class FindTVCMMaterialListManager {

    /** シングルトンインスタンス */
    private static FindTVCMMaterialListManager _manager = new FindTVCMMaterialListManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindTVCMMaterialListManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindTVCMMaterialListManager getInstance() {
        return _manager;
    }

    /**
     * TVCM素材一覧出力情報を検索します
     * @param cond 検索条件
     * @return ラジオ版AllocationPicture出力情報
     * @throws HAMException 処理中にエラーが発生した場合
     */
    public FindTVCMMaterialListResult findTVCMMaterialList(FindTVCMMaterialListCondition TVCMcond) throws HAMException {

        //検索結果
        FindTVCMMaterialListResult result = new FindTVCMMaterialListResult();

        //検索条件
        Mbj52SzTntUserCondition mbj52Cond = new Mbj52SzTntUserCondition();
        FindSecGrpUserCondition secGrpUserCond = new FindSecGrpUserCondition();

        //TVCM素材一覧
        FindTVCMMaterialListDAO materialListDao = FindTVCMMaterialListDAOFactory.createFindTVCMMaterialListDAOFactory();
        result.setTVCMMatelialList(materialListDao.findTVCMMaterialList(TVCMcond));

        //素材一覧(共有OA期間)
        Tbj43SozaiKanriListCmnOADAO tbj43dao = Tbj43SozaiKanriListCmnOADAOFactory.createTbj43SozaiKanriListCmnOADAO();
        Tbj43SozaiKanriListCmnOACondition tbj43cond = new Tbj43SozaiKanriListCmnOACondition();
        //検索条件を文字型→日付型に変換
        SimpleDateFormat sdf = new SimpleDateFormat("yyyyMM");
        try {
            tbj43cond.setSozaiym(sdf.parse(TVCMcond.getYearMonth()));
        } catch (ParseException e) {
            e.printStackTrace();
        }
        result.setTVCMSozaiOA(tbj43dao.findSozaiThreeMonth(tbj43cond));

        //契約情報
        FindTVCMMaterialListContractInfoDAO contractInfoDao = FindTVCMMaterialListContractInfoDAOFactory.createFindTVCMMaterialListContractInfoDAOFactory();
        result.setTVCMConterctInfo(contractInfoDao.findTVCMMaterialListContractInfo(TVCMcond));

        //特記事項
        FindTVCMMaterialListRemarksDAO remarksDao = FindTVCMMaterialListRemarksDAOFactory.createFindTVCMMaterialListRemarksDAOFactory();
        result.setTVCMRemarks(remarksDao.findTVCMMaterialListRemarks(TVCMcond));

        //最終更新者
        FindTVCMMaterialListLastUpdateUserDAO lastUpdateUserDao = FindTVCMMaterialListLastUpdateUserDAOFactory.createFindTVCMMaterialListLastUpdateUserDAOFactory();
        result.setTVCMLastUpdateUser(lastUpdateUserDao.findTVCMMaterialListLastUpdateUser(TVCMcond));

        //車種担当者情報
        Mbj52SzTntUserDAO mbj52Dao = Mbj52SzTntUserDAOFactory.createMbj52SzTntUserDAO();
        result.setSzTntUserList(mbj52Dao.findSyatanUser(mbj52Cond));

        //セキュリティグループユーザー情報
        FindSecGrpUserDAO secGrpUserDAO = FindSecGrpUserDAOFactory.createFindSecGrpUserDAOFactory();
        result.setHCHMSecGrpUserList(secGrpUserDAO.findHCHMSecGrpUser(secGrpUserCond));

        return result;
    }

}
