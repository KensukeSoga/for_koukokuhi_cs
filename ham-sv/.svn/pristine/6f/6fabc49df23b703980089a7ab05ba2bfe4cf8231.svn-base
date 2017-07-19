package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj28BillDaysCondition;
import jp.co.isid.ham.common.model.Mbj28BillDaysDAO;
import jp.co.isid.ham.common.model.Mbj28BillDaysDAOFactory;
import jp.co.isid.ham.common.model.Mbj28BillDaysVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.Tbj05EstimateItemCondition;
import jp.co.isid.ham.common.model.Tbj05EstimateItemDAO;
import jp.co.isid.ham.common.model.Tbj05EstimateItemDAOFactory;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailCondition;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailDAO;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailDAOFactory;
import jp.co.isid.ham.common.model.Tbj07EstimateCreateCondition;
import jp.co.isid.ham.common.model.Tbj07EstimateCreateDAO;
import jp.co.isid.ham.common.model.Tbj07EstimateCreateDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * HC見積一覧データを管理する
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/4 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class HCEstimateListManager {

    /** シングルトンインスタンス */
    private static HCEstimateListManager _manager = new HCEstimateListManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private HCEstimateListManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static HCEstimateListManager getInstance() {
        return _manager;
    }

    /**
     * HC見積一覧検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindHCEstimateListResult findHCEstimateList(FindHCEstimateListCondition cond) throws HAMException {

        FindHCEstimateListResult result = new FindHCEstimateListResult();

        // 画面項目表示列制御マスタ取得
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormId());
        result.setDisplayControl(dcdao.selectVO(dccond));

        // 請求書出力年月マスタ取得
        Mbj28BillDaysDAO billdao = Mbj28BillDaysDAOFactory.createMbj28BillDaysDAO();
        Mbj28BillDaysCondition billcond = new Mbj28BillDaysCondition();
        billcond.setPhase(cond.getPhase());
        billcond.setYear(cond.getYearMonth().substring(0, 4));
        billcond.setMonth(cond.getYearMonth().substring(5));
        result.setBillDays(billdao.selectVO(billcond));

        // HC見積一覧(制作原価)取得
        FindHCEstimateListCostDAO costDao = FindHCEstimateListDAOFactory.createFindHCEstimateListCostDao();
        FindHCEstimateListCostCondition costcond = new FindHCEstimateListCostCondition();
        costcond.setPhase(cond.getPhase());
        costcond.setYearMonth(cond.getYearMonth());
        costcond.setClassDiv("0");
        costcond.setUserType(cond.getUserType());
        costcond.setHamId(cond.getHamId());
        result.setCostVoList(costDao.selectVO(costcond));

        // HC見積一覧(制作費)取得
        FindHCEstimateListTotalDAO totalDao = FindHCEstimateListDAOFactory.createFindHCEstimateListTotalDao();
        FindHCEstimateListTotalCondition totalcond = new FindHCEstimateListTotalCondition();
        totalcond.setPhase(cond.getPhase());
        totalcond.setYearMonth(cond.getYearMonth());
        totalcond.setClassDiv("1");
        totalcond.setUserType(cond.getUserType());
        totalcond.setHamId(cond.getHamId());
        result.setTotalVoList(totalDao.selectVO(totalcond));

        // HC見積一覧(見積案件)(制作原価)取得
        FindHCEstimateListItemDAO itemDao = FindHCEstimateListDAOFactory.createFindHCEstimateListItemDao();
        FindHCEstimateListItemCondition costItemCond = new FindHCEstimateListItemCondition();
        costItemCond.setPhase(cond.getPhase());
        costItemCond.setYearMonth(cond.getYearMonth());
        costItemCond.setEstimateClass("0");
        costItemCond.setEstSeqNo(null);
        costItemCond.setCodeType(cond.getCodeType());
        costItemCond.setHamId(cond.getHamId());
        result.setCostItemVoList(itemDao.selectVO(costItemCond));

        // HC見積一覧(見積案件)(制作費)取得
        FindHCEstimateListItemCondition totalItemCond = new FindHCEstimateListItemCondition();
        totalItemCond.setPhase(cond.getPhase());
        totalItemCond.setYearMonth(cond.getYearMonth());
        totalItemCond.setEstimateClass("1");
        totalItemCond.setEstSeqNo(null);
        totalItemCond.setCodeType(cond.getCodeType());
        totalItemCond.setHamId(cond.getHamId());
        result.setTotalItemVoList(itemDao.selectVO(totalItemCond));

        // 変更確認データ(制作原価)取得
        FindHCEstimateListDiffDAO diffDao = new FindHCEstimateListDiffDAO();
        FindHCEstimateListDiffCondition diffCostCond = new FindHCEstimateListDiffCondition();
        List<BigDecimal> estSeqNoCost = new ArrayList<BigDecimal>();
        for (FindHCEstimateListItemVO itemVo : result.getCostItemVoList()) {
            estSeqNoCost.add(itemVo.getESTSEQNO());
        }
        diffCostCond.setEstSeqNoList(estSeqNoCost);
        diffCostCond.setPhase(cond.getPhase());
        diffCostCond.setYearMonth(cond.getYearMonth());
        result.setCostDiffVoList(diffDao.selectVO(diffCostCond));

        // 変更確認データ(制作費)取得
        FindHCEstimateListDiffTotalDAO diffTotalDao = new FindHCEstimateListDiffTotalDAO();
        FindHCEstimateListDiffTotalCondition diffTotalCond = new FindHCEstimateListDiffTotalCondition();
        List<BigDecimal> estSeqNoTotal = new ArrayList<BigDecimal>();
        for (FindHCEstimateListItemVO itemVo : result.getTotalItemVoList()) {
            estSeqNoTotal.add(itemVo.getESTSEQNO());
        }
        diffTotalCond.setEstSeqNoList(estSeqNoTotal);
        diffTotalCond.setPhase(cond.getPhase());
        diffTotalCond.setYearMonth(cond.getYearMonth());
        result.setTotalDiffVoList(diffTotalDao.selectVO(diffTotalCond));

        // 機能制御Infoの取得
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormId());
        funccond.setFunctype(cond.getFuncType());
        funccond.setHamid(cond.getHamId());
        funccond.setUsertype(cond.getUsertype());
        funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());

        // セキュリティInfoの取得
        SecurityInfoManager secmanager = SecurityInfoManager.getInstance();
        SecurityInfoCondition seccond = new SecurityInfoCondition();
        seccond.setHamid(cond.getHamId());
        seccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        seccond.setSecuritycd(cond.getSecuritycd());
        seccond.setUsertype(cond.getUsertype());
        result.setSecurityInfoVoList(secmanager.getSecurityInfo(seccond).getSecurityInfo());

        return result;
    }

    /**
     * HC見積一覧登録
     * @param vo 登録データ
     * @return 登録結果
     * @throws HAMException
     */
    public RegisterHCEstimateListResult registerHCEstimateList(RegisterHCEstimateListVO vo) throws HAMException {

        RegisterHCEstimateListResult result = new RegisterHCEstimateListResult();

        // HC見積一覧(見積案件)更新チェック
        if (!checkUpdate(vo)) {
            throw new HAMException("排他エラー", "BJ-E0005");
        }

        // 年月の型変換.
        Date dtYearMonth = null;
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM");
        try {
            dtYearMonth = sdf.parse(vo.getYearMonth());
        } catch (ParseException e) {
            new HAMException(e.getMessage(), "BJ-E0002");
        }

        // インスタンス作成.
        Tbj07EstimateCreateDAO createDao = Tbj07EstimateCreateDAOFactory.createTbj07EstimateCreateDAO();
        Tbj06EstimateDetailDAO detailDao = Tbj06EstimateDetailDAOFactory.createTbj06EstimateDetailDAO();
        Tbj05EstimateItemDAO itemDao = Tbj05EstimateItemDAOFactory.createTbj05EstimateItemDAO();

        for (BigDecimal bdEstSeqNo : vo.getEstseqno()) {
            // 見積案件CR制作費削除
            Tbj07EstimateCreateCondition createCond = new Tbj07EstimateCreateCondition();
            createCond.setPhase(vo.getPhase());
            createCond.setCrdate(dtYearMonth);
            createCond.setEstseqno(bdEstSeqNo);
            createCond.setEstdetailseqno(BigDecimal.valueOf(0));
            createDao.deleteEstimateCreate(createCond);

            // 見積明細削除
            Tbj06EstimateDetailCondition detailCond = new Tbj06EstimateDetailCondition();
            detailCond.setPhase(vo.getPhase());
            detailCond.setCrdate(dtYearMonth);
            detailCond.setEstseqno(bdEstSeqNo);
            detailCond.setEstdetailseqno(BigDecimal.valueOf(0));
            detailDao.deleteEstimateDetail(detailCond);

            // 見積案件削除
            Tbj05EstimateItemCondition itemCond = new Tbj05EstimateItemCondition();
            itemCond.setPhase(vo.getPhase());
            itemCond.setCrdate(dtYearMonth);
            itemCond.setEstseqno(bdEstSeqNo);
            itemDao.deleteEstimateItem(itemCond);
        }

        return result;
    }

    /**
     * HC見積一覧(見積案件)更新チェック
     * @param vo 登録データ
     * @return true：チェックOK、false：チェックNG
     * @throws HAMException
     */
    private boolean checkUpdate(RegisterHCEstimateListVO vo) throws HAMException {

        // HC見積一覧(見積案件)取得
        FindHCEstimateListItemDAO hcItemDao = FindHCEstimateListDAOFactory.createFindHCEstimateListItemDao();
        List<FindHCEstimateListItemVO> itemVoList = null;
        if (vo.getCost().equals("1")) {
            FindHCEstimateListItemCondition costItemCond = new FindHCEstimateListItemCondition();
            costItemCond.setPhase(vo.getPhase());
            costItemCond.setYearMonth(vo.getYearMonth());
            costItemCond.setEstimateClass("0");
            costItemCond.setEstSeqNo(null);
            costItemCond.setCodeType(vo.getCodeType());
            costItemCond.setHamId(vo.getHamId());
            itemVoList = hcItemDao.selectVO(costItemCond);
        }
        else {
            FindHCEstimateListItemCondition totalItemCond = new FindHCEstimateListItemCondition();
            totalItemCond.setPhase(vo.getPhase());
            totalItemCond.setYearMonth(vo.getYearMonth());
            totalItemCond.setEstimateClass("1");
            totalItemCond.setEstSeqNo(null);
            totalItemCond.setCodeType(vo.getCodeType());
            totalItemCond.setHamId(vo.getHamId());
            itemVoList = hcItemDao.selectVO(totalItemCond);
        }

        // 比較を簡略化するために、HashMapに型を変換
        HashMap<BigDecimal, Date> hm = new HashMap<BigDecimal, Date>();
        for (FindHCEstimateListItemVO elVo : itemVoList) {
            hm.put(elVo.getESTSEQNO(), elVo.getUPDDATE());
        }

        boolean error = false;

        // 削除対象排他チェック
        if (vo.getEstseqno() != null && vo.getEstseqno().size() > 0) {
            for (BigDecimal estseqno : vo.getEstseqno()) {
                if (!hm.containsKey(estseqno)) {
                    error = true;
                    break;
                }

                if (vo.getLatestUpdDate().before(hm.get(estseqno))) {
                    error = true;
                    break;
                }
            }

            if (error) {
                return false;
            }
        }

        return true;
    }

    /**
     * 請求書出力年月マスタ登録
     *
     * @return 登録結果
     * @throws HAMException
     */
    public RegisterBillDaysResult registerBillDays(Mbj28BillDaysVO vo) throws HAMException {

        RegisterBillDaysResult result = new RegisterBillDaysResult();

        Mbj28BillDaysDAO billDaysDao = Mbj28BillDaysDAOFactory.createMbj28BillDaysDAO();
        Mbj28BillDaysCondition cond = new Mbj28BillDaysCondition();
        cond.setPhase(vo.getPHASE());
        cond.setYear(vo.getYEAR());
        cond.setMonth(vo.getMONTH());
        List<Mbj28BillDaysVO> voList = billDaysDao.selectVO(cond);

        if (voList.size() > 0) {
            billDaysDao.updateVO(vo);
        }
        else {
            billDaysDao.insertVO(vo);
        }

        return result;
    }

}
