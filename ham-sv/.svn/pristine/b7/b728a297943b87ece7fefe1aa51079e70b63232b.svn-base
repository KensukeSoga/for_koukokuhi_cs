package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.Calendar;
import java.util.List;

import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanCondition;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoCondition;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAOFactory;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindGrossSumManager {

    /** シングルトンインスタンス */
    private static FindGrossSumManager _manager = new FindGrossSumManager();

    private BigDecimal _phase;

    private String _term;

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindGrossSumManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindGrossSumManager getInstance() {
        return _manager;
    }

    /**
     * 営業作業台帳のグロス合計を取得
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindGrossSumResult findGrossSum(Tbj02EigyoDaichoCondition cond)
        throws HAMException {

        FindGrossSumResult result = new FindGrossSumResult();

        getPhaseInfo(cond);

        //合計を取る対象の媒体管理状況Noを取得
        Tbj01MediaPlanCondition plancond = new Tbj01MediaPlanCondition();
        Tbj01MediaPlanDAO plandao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        plancond.setDcarcd(cond.getDcarcd());
        plancond.setMediacd(cond.getMediacd());
        plancond.setPhase(_phase);
        plancond.setTerm(_term);
        plancond.setKikanfrom(cond.getKikanfrom());
        plancond.setKikanto(cond.getKikanto());
        List<Tbj01MediaPlanVO> planlist = plandao.findMediaPlanNo(plancond);

        //対象が見つかれば、その媒体状況管理NOで営業作業台帳のグロスから合計を取得
        List<Tbj02EigyoDaichoVO> edsum = null;
        if (planlist.size() != 0) {
            Tbj02EigyoDaichoDAO eddao = Tbj02EigyoDaichoDAOFactory.createTbj02EigyoDaichoDAO();
            edsum = eddao.FindEigyoDaichoFeeSUM(planlist.get(0).getMEDIAPLANNO().toString());
        }

        result.setGrossSum(edsum);
        return result;
    }

    /**
     * フェイズ情報を取得
     * @param vo 更新・登録対象vo
     * @throws HAMException
     */
    private void getPhaseInfo(Tbj02EigyoDaichoCondition cond) throws HAMException {
        Mbj12CodeDAO codedao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codecond = new Mbj12CodeCondition();
        codecond.setCodetype("17");
        codecond.setKeycode("0");
        List<Mbj12CodeVO> coderesult = codedao.selectVO(codecond);

        Calendar cal = Calendar.getInstance();
        cal.setTime(cond.getKikanfrom());

        int year = cal.get(Calendar.YEAR);
        int month = cal.get(Calendar.MONTH)+1;
        int standerdYear = Integer.parseInt(coderesult.get(0).getYOBI1());
        if (month < 4)
        {
            _phase = BigDecimal.valueOf(year - standerdYear -1);
        }
        else
        {
            _phase = BigDecimal.valueOf(year - standerdYear);
        }
        if (month >= 4 && month <= 9)
        {
            _term = "上";
        }
        else if (month <= 3 || month >= 10)
        {
            _term = "下";
        }
    }
}
