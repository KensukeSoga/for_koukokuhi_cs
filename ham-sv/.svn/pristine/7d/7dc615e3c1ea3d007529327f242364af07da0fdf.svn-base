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

    /** シングルトンインスタンス */
    private static FindCooperationDataManager _manager = new FindCooperationDataManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindCooperationDataManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindCooperationDataManager getInstance() {
        return _manager;
    }

    /**
     * DKB連携用データを検索します
     *
     * @return FindCooperationDataResult DKB連携用データ
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindCooperationDataResult findCooperationData(FindCooperationDataCondition cond)
            throws HAMException {

        //検索結果
        FindCooperationDataResult result = new FindCooperationDataResult();

        String items = "'掲載料','色刷料','指定料','二連版料','組替料','変形スペース料','スプリットラン料'";
        String itemCd = null;
        String codetype = "'26','27','28','29','30'";

        // ******************************************************
        // 取引先情報の取得
        // ******************************************************
        RepaVbjaMeu14ThsTntTrDAO chargedao = RepaVbjaMeu14ThsTntTrDAOFactory.createRepaVbjaMeu14ThsTntTrDAO();
        RepaVbjaMeu14ThsTntTrCondition chargecond = new RepaVbjaMeu14ThsTntTrCondition();
        chargecond.setEgsyocd("10");
        chargecond.setThskgycd("382743");
        chargecond.setSeqno("06");
        chargecond.setTrtntseqno("04");
        List<RepaVbjaMeu14ThsTntTrVO> chargelist = chargedao.findCharge(chargecond,cond.getEigyobi(),cond.getEigyobi());
        //取引先情報が見つからなかったら一巻の終わり
        if (chargelist.size() == 0) {
            throw new HAMException("検索","BJ-E0002");
        }

        result.setRepaVbjaMeu14ThsTntTr(chargelist);

        // ******************************************************
        // 費目情報の取得(費目は必要なものを全部取ってきちゃう)
        // ******************************************************
        //新聞の業務区分を取得
        RepaVbjaMeu29CcDAO gyomudao = RepaVbjaMeu29CcDAOFactory.createRepaVbjaMeu29CcDAO();
        List<RepaVbjaMeu29CcVO> gyomulist = gyomudao.FindCodeMasterByCode("'87'", "新聞");
        RepaVbjaMeu29CcVO gyomuVO = gyomulist.get(0);

        FindItemDAO itemdao = FindCooperationDataDAOFactory.createFindItemDAO();
        FindItemCondition itemcond = new FindItemCondition();
        itemcond.setItems(items);
        itemcond.setKikanFrom(cond.getEigyobi());
        itemcond.setKikanTo(cond.getEigyobi());
        itemcond.setWorkFlg(gyomuVO.getKYCD());
        List<FindItemVO> itemlist = itemdao.findItem(itemcond);
        result.setItem(itemlist);

        //スペース(スペースのカラムに入力可能な値とそのコード)を取得
        RepaVbjaMeu29CcCondition spaceCond = new RepaVbjaMeu29CcCondition();
        spaceCond.setKycdknd("WE");
        result.setSpace(gyomudao.selectVO(spaceCond));

        for (FindItemVO itemvo : itemlist) {
            itemCd = itemCd + itemvo.getHMOKCD();
        }

        // ******************************************************
        // HAMのコードマスタを取得
        // ******************************************************
        Mbj12CodeDAO codedao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codecond = new Mbj12CodeCondition();
        codecond.setCodetype(codetype);
        List<Mbj12CodeVO> codelist = codedao.FindManyCd(codecond);
        result.setMbj12Code(codelist);

        //営業作業台帳データに対するデータを取得
        List<FindSocietyDataVO> societylist = null;
        for (Tbj02EigyoDaichoVO getvo:cond.getTbj02EigyoDaicho())
        {
            // ******************************************************
            // 組織情報を取得
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
