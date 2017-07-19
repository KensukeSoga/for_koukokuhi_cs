package jp.co.isid.ham.media.model;

import java.util.List;
import java.util.ArrayList;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.RepaVbjaMeu20MsMzBtCondition;
import jp.co.isid.ham.common.model.RepaVbjaMeu20MsMzBtDAO;
import jp.co.isid.ham.common.model.RepaVbjaMeu20MsMzBtDAOFactory;
import jp.co.isid.ham.common.model.RepaVbjaMeu20MsMzBtVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindOrderSelectManager {

    /** シングルトンインスタンス */
    private static FindOrderSelectManager _manager = new FindOrderSelectManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindOrderSelectManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindOrderSelectManager getInstance() {
        return _manager;
    }


    /**
     * 営業作業台帳情報を検索
     * @return FindOrderSelectResult 営業作業台帳情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindOrderSelectResult findOrderSelect(FindOrderSelectCondition cond)
            throws HAMException {

        //検索結果
        FindOrderSelectResult result = new FindOrderSelectResult();

        // ******************************************************
        // 営業作業台帳情報の取得
        // ******************************************************
        FindOrderSelectDAO orderdao = FindOrderSelectDAOFactory.createOrderSelectDAOFactory();

        List<FindOrderSelectVO> tmpList = orderdao.FindOrderSelect(cond);
        List<FindOrderSelectVO> retList = new ArrayList<FindOrderSelectVO>();
        for (FindOrderSelectVO getvo:tmpList)
        {
            RepaVbjaMeu20MsMzBtDAO msmzbtdao = RepaVbjaMeu20MsMzBtDAOFactory.createRepaVbjaMeu20MsMzBtDAO();
            RepaVbjaMeu20MsMzBtCondition msmzbtcond = new RepaVbjaMeu20MsMzBtCondition();

            int lenMediasCd = getvo.getMEDIASCD().length();

            //媒体種別コードと県版コードを分解
            if (lenMediasCd != 6)
            {   // 媒体種別コードが6桁でない場合は無効
                continue;
            }
            String mediaCd = getvo.getMEDIASCD().substring(0,lenMediasCd - 2);
            String kbanCd = getvo.getMEDIASCD().substring(lenMediasCd - 2, lenMediasCd);

            msmzbtcond.setSzkbn("A");   // 新聞
            msmzbtcond.setSinzatsubtaicd(mediaCd);
            msmzbtcond.setKbancd(kbanCd);
            List<RepaVbjaMeu20MsMzBtVO> getmsmzbtlist = msmzbtdao.selectVO(msmzbtcond);
            if ((getmsmzbtlist == null) || (getmsmzbtlist.size() == 0))
            {   // 媒体種別コードに該当した新雑媒体マスタがない場合は無効とする
                continue;
            }

            retList.add(getvo);

        }
        result.setOrderSelect(retList);

        // ******************************************************
        // 画面項目表示列制御マスタ取得
        // ******************************************************
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormID());
        result.setDisplayControl(dcdao.selectVO(dccond));

        return result;
    }
}
