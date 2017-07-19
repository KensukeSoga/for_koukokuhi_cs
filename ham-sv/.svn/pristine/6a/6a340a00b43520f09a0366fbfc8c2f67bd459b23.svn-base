package jp.co.isid.ham.media.model;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAOFactory;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindInputRejectionManager {

    /** シングルトンインスタンス */
    private static FindInputRejectionManager _manager = new FindInputRejectionManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindInputRejectionManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindInputRejectionManager getInstance() {
        return _manager;
    }

    /**
     * 入力拒否情報を検索します
     *
     * @return FindInputRejectionResult 入力拒否情報
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public FindInputRejectionResult findInputRejection(FindInputRejectionCondition cond)
    throws HAMException {

        //検索結果
        FindInputRejectionResult result = new FindInputRejectionResult();

        //*******************************************
        //媒体状況管理データを検索します.
        //*******************************************
        FindInputRejectionDAO fdao = FindInputRejectionDAOFactory.createFindInputRejectionDAO();
        List<FindInputRejectionVO> dlist = fdao.findMediaPlanInputRejection(cond.getCampCd());
        result.setInputReject(dlist);

        //*******************************************
        //営業作業台帳を検索します.
        //*******************************************
        //まずは媒体状況管理を検索し、媒体管理Noの取得を行います.
        Tbj01MediaPlanDAO mdao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> mlist = mdao.findMediaPlanByCampCd(cond.getCampCd());
        Tbj02EigyoDaichoDAO edao = Tbj02EigyoDaichoDAOFactory.createTbj02EigyoDaichoDAO();
        SimpleDateFormat sdf1 = new SimpleDateFormat("yyyy/MM");
        ArrayList<FindInputRejectionVO> addListvo = new ArrayList<FindInputRejectionVO>();
        for (Tbj01MediaPlanVO mvo : mlist) {
            List<Tbj02EigyoDaichoVO> elist = edao.FindEigyoDaichoByMediaPlanNo(mvo.getMEDIAPLANNO().toString());
            if (elist.size() != 0) {
                FindInputRejectionVO addvo = new FindInputRejectionVO();
                addvo.setMEDIACD(mvo.getMEDIACD());
                addvo.setYOTEIYM(sdf1.format(mvo.getYOTEIYM()));
                addListvo.add(addvo);
            }
        }
        result.setInputRejectByEigyo(addListvo);

        return result;
    }

}
