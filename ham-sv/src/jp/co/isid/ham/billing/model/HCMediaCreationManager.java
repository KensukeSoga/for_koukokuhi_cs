package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;

import jp.co.isid.ham.common.model.CarListCondition;
import jp.co.isid.ham.common.model.CarListDAO;
import jp.co.isid.ham.common.model.CarListDAOFactory;
import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj06HcBumonCondition;
import jp.co.isid.ham.common.model.Mbj06HcBumonDAO;
import jp.co.isid.ham.common.model.Mbj06HcBumonDAOFactory;
import jp.co.isid.ham.common.model.Mbj07HcUserCondition;
import jp.co.isid.ham.common.model.Mbj07HcUserDAO;
import jp.co.isid.ham.common.model.Mbj07HcUserDAOFactory;
import jp.co.isid.ham.common.model.Mbj09HiyouCondition;
import jp.co.isid.ham.common.model.Mbj09HiyouDAO;
import jp.co.isid.ham.common.model.Mbj09HiyouDAOFactory;
import jp.co.isid.ham.common.model.Mbj09HiyouVO;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj21CalendarCondition;
import jp.co.isid.ham.common.model.Mbj21CalendarDAO;
import jp.co.isid.ham.common.model.Mbj21CalendarDAOFactory;
import jp.co.isid.ham.common.model.Mbj21CalendarVO;
import jp.co.isid.ham.common.model.Mbj26BillGroupVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.MediaListCondition;
import jp.co.isid.ham.common.model.MediaListDAO;
import jp.co.isid.ham.common.model.MediaListDAOFactory;
import jp.co.isid.ham.common.model.MediaListVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcCondition;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcDAO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcDAOFactory;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.Tbj03MediaMngCondition;
import jp.co.isid.ham.common.model.Tbj03MediaMngVO;
import jp.co.isid.ham.common.model.Tbj04MediaMngEstimateDetailCondition;
import jp.co.isid.ham.common.model.Tbj04MediaMngEstimateDetailDAO;
import jp.co.isid.ham.common.model.Tbj04MediaMngEstimateDetailDAOFactory;
import jp.co.isid.ham.common.model.Tbj04MediaMngEstimateDetailVO;
import jp.co.isid.ham.common.model.Tbj05EstimateItemCondition;
import jp.co.isid.ham.common.model.Tbj05EstimateItemDAO;
import jp.co.isid.ham.common.model.Tbj05EstimateItemDAOFactory;
import jp.co.isid.ham.common.model.Tbj05EstimateItemVO;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailCondition;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailDAO;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailDAOFactory;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.constants.HAMConstants;

/**
 * <P>
 * HC媒体費作成データを管理する
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/10 T.Fujiyoshi)<BR>
 * ・請求業務変更対応(2015/08/31 HLC S.Fujimoto)<BR>
 * ・請求業務変更対応(2016/01/27 HLC K.Soga)<BR>
 * ・請求業務変更対応(2016/02/04 HLC K.Oki)<BR>
 * ・請求業務変更不具合対応(2016/03/16 HLC K.Soga)<BR>
 * ・HDX対応(2016/04/18 HLC K.Soga)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class HCMediaCreationManager {

    /** シングルトンインスタンス */
    public static HCMediaCreationManager _manager = new HCMediaCreationManager();

    /** シングルトンの為、インスタンス化を禁止します */
    private HCMediaCreationManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static HCMediaCreationManager getInstance() {
        return _manager;
    }

    /**
     * HC媒体費作成検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindHCMediaCreationResult findHCMediaCreation(FindHCMediaCreationCondition cond) throws HAMException {

        FindHCMediaCreationResult result = new FindHCMediaCreationResult();

        // 画面項目表示列制御マスタ取得
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormId());
        result.setDisplayControl(dcdao.selectVO(dccond));

        // コードマスタ取得
        Mbj12CodeDAO codedao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        List<Mbj12CodeVO> codeVoList = new ArrayList<Mbj12CodeVO>();
        for (String codeType : cond.getCodeType()) {
           Mbj12CodeCondition codecond = new Mbj12CodeCondition();
           codecond.setCodetype(codeType);
           codeVoList.addAll(codedao.selectVO(codecond));
        }
        result.setCode(codeVoList);

        // 部門マスタ取得
        Mbj06HcBumonDAO bumondao = Mbj06HcBumonDAOFactory.createMbj06HcBumonDAO();
        Mbj06HcBumonCondition bumoncond = new Mbj06HcBumonCondition();
        result.setBumon(bumondao.selectVO(bumoncond));

        // カレンダーマスタ取得
        Mbj21CalendarDAO calendarDao = Mbj21CalendarDAOFactory.createMbj21CalendarDAO();
        Mbj21CalendarCondition calendarcond = new Mbj21CalendarCondition();
        calendarcond.setDatakbn("01");
        /** 2016/03/15 請求業務変更不具合対応 HLC K.Soga MOD Start */
        //calendarcond.setCalendarym(cond.getYearMonth().replaceAll("/", ""));
        calendarcond.setCalendarym(DateUtil.getPrevMonth(cond.getYearMonth()).replaceAll("/", ""));
        /** 2016/03/15 請求業務変更不具合対応 HLC K.Soga MOD End */
        result.setCalendar(calendarDao.selectVO(calendarcond));

        // HCユーザマスタ取得
        Mbj07HcUserDAO userdao = Mbj07HcUserDAOFactory.createMbj07HcUserDAO();
        Mbj07HcUserCondition usercond = new Mbj07HcUserCondition();
        result.setUser(userdao.selectVO(usercond));

        // 車種取得
        CarListDAO carDao = CarListDAOFactory.createCarListDAO();
        CarListCondition carCond = new CarListCondition();
        carCond.setSecType("0");
        carCond.setHamid(cond.getHamId());
        result.setCar(carDao.findCarList(carCond));

        // 媒体取得
        MediaListDAO mediaDao = MediaListDAOFactory.createMediaListDAO();
        MediaListCondition mediaCond = new MediaListCondition();
        mediaCond.setHamid(cond.getHamId());
        result.setMedia(mediaDao.findMediaList(mediaCond));

        // H新モデルコスト合計取得
        FindSumHmCostDAO sumHmCostDao = FindHCMediaCreationDAOFactory.createFindSumHmCostDao();
        FindSumHmCostCondition sumHmCostCond = new FindSumHmCostCondition();
        sumHmCostCond.setYearMonth(cond.getYearMonth());
        List<String> dcarCd = new LinkedList<String>();
        if (result.getCar() != null && result.getCar().size() > 0)
        {
            for (CarListVO car : result.getCar()) {
                dcarCd.add(car.getDCARCD());
            }
        }
        sumHmCostCond.setDCarCd(dcarCd);
        List<String> mediaCd = new LinkedList<String>();
        if (result.getMedia() != null && result.getMedia().size() > 0)
        {
            for (MediaListVO media : result.getMedia()) {
                mediaCd.add(media.getMEDIACD());
            }
        }
        sumHmCostCond.setMediaCd(mediaCd);
        sumHmCostDao.setCondition(sumHmCostCond);
        result.setSumHmCost(sumHmCostDao.selectVO());

        // 媒体費管理取得インスタンスを作成
        FindMediaMngDAO mediaMngDao = FindHCMediaCreationDAOFactory.createFindMediaMngDao();

        // 媒体費管理登録インスタンスを生成
        RegisterMediaMngDAO regMediaMngDao = FindHCMediaCreationDAOFactory.createRegisterMediaMngDao();
        String strYear = cond.getYearMonth().substring(0, 4);
        String strMonth = cond.getYearMonth().substring(5);

        if (result.getSumHmCost() != null && result.getSumHmCost().size() > 0) {
            for (FindSumHmCostVO costVo : result.getSumHmCost()) {
                // 媒体費管理取得
                Tbj03MediaMngCondition mediaMngCondForCheck = new Tbj03MediaMngCondition();
                mediaMngCondForCheck.setPhase(cond.getPhase());
                mediaMngCondForCheck.setMdyear(strYear);
                mediaMngCondForCheck.setMdmonth(strMonth);
                mediaMngCondForCheck.setDcarcd(costVo.getDCARCD());
                mediaMngCondForCheck.setMediacd(costVo.getMEDIACD());
                List<Tbj03MediaMngVO> mediaMngVo = mediaMngDao.selectVO(mediaMngCondForCheck);
                if (mediaMngVo == null || mediaMngVo.size() <= 0) {
                    // 媒体費管理登録
                    Tbj03MediaMngVO insMediaMngVo = new Tbj03MediaMngVO();
                    insMediaMngVo.setPHASE(cond.getPhase());
                    insMediaMngVo.setMDYEAR(strYear);
                    insMediaMngVo.setMDMONTH(strMonth);
                    insMediaMngVo.setDCARCD(costVo.getDCARCD());
                    insMediaMngVo.setMEDIACD(costVo.getMEDIACD());
                    insMediaMngVo.setHMCOSTTOTAL(costVo.getHMCOST());
                    insMediaMngVo.setCRTNM(cond.getUpdNm());
                    insMediaMngVo.setCRTAPL(cond.getFormId());
                    insMediaMngVo.setCRTID(cond.getHamId());
                    insMediaMngVo.setUPDNM(cond.getUpdNm());
                    insMediaMngVo.setUPDAPL(cond.getFormId());
                    insMediaMngVo.setUPDID(cond.getHamId());
                    regMediaMngDao.insertMediaMng(insMediaMngVo);
                }
            }
        }

        // 媒体費管理取得
        Tbj03MediaMngCondition mediaMngCond = new Tbj03MediaMngCondition();
        mediaMngCond.setPhase(cond.getPhase());
        mediaMngCond.setMdyear(strYear);
        mediaMngCond.setMdmonth(strMonth);
        result.setMediaMng(mediaMngDao.selectVO(mediaMngCond));

        if (result.getMediaMng().size() > 0)
        {
            List<String> tbj03DCarCd = new LinkedList<String>();
            List<String> tbj03MediaCd = new LinkedList<String>();
            for (Tbj03MediaMngVO mediaMngVo : result.getMediaMng()) {
                if (!tbj03DCarCd.contains(mediaMngVo.getDCARCD())) {
                    tbj03DCarCd.add(mediaMngVo.getDCARCD());
                }
                if (!tbj03MediaCd.contains(mediaMngVo.getMEDIACD())) {
                    tbj03MediaCd.add(mediaMngVo.getMEDIACD());
                }
            }

            // 媒体・商品紐付けマスタ取得
            FindMediaProductDAO mediaProductDao = FindHCMediaCreationDAOFactory.createFindMediaProductDao();
            FindMediaProductCondition mediaProductCond = new FindMediaProductCondition();
            mediaProductCond.setDCarCd(tbj03DCarCd);
            mediaProductCond.setMediaCd(tbj03MediaCd);
            result.setMediaProduct(mediaProductDao.selectVO(mediaProductCond));
        }

        // 媒体費見積明細管理取得
        FindMediaMngEstDtlDAO estDtlDao = FindHCMediaCreationDAOFactory.createFindMediaMngEstDtlDao();
        Tbj04MediaMngEstimateDetailCondition estDtlCond = new Tbj04MediaMngEstimateDetailCondition();
        estDtlCond.setPhase(cond.getPhase());
        estDtlCond.setMdyear(strYear);
        estDtlCond.setMdmonth(strMonth);
        result.setEstDtl(estDtlDao.selectVO(estDtlCond));

        // 見積案件/見積明細取得
        FindEstItemDtlDAO itemDtlDao = FindHCMediaCreationDAOFactory.createFindEstItemDtlDao();
        FindEstItemDtlCondition itemDtlCond = new FindEstItemDtlCondition();
        itemDtlCond.setPhase(cond.getPhase());
        itemDtlCond.setYearMonth(cond.getYearMonth());
        itemDtlCond.setEstimateClass(cond.getEstimateClass());
        result.setEstItemDtl(itemDtlDao.selectVO(itemDtlCond));

        if (result.getEstItemDtl().size() > 0) {
            List<String> hcbumonCd = new LinkedList<String>();
            List<String> productCd = new LinkedList<String>();
            for (FindEstItemDtlVO itemDtlVo : result.getEstItemDtl()) {
                hcbumonCd.add(itemDtlVo.getHCBUMONCD());
                productCd.add(itemDtlVo.getPRODUCTCD());
            }

            // 商品マスタ取得
            FindHCProductDAO productDao = FindHCEstimateCreationDAOFactory.createFindHCProductDao();
            FindHCProductCondition productCond = new FindHCProductCondition();
            productCond.setHCBumonCd(hcbumonCd);
            productCond.setProductCd(productCd);
            result.setProduct(productDao.selectVO(productCond));
        }

        // 全社コードマスタ取得
        RepaVbjaMeu29CcDAO menu29Dao = RepaVbjaMeu29CcDAOFactory.createRepaVbjaMeu29CcDAO();
        RepaVbjaMeu29CcCondition menu29Cond = new RepaVbjaMeu29CcCondition();
        menu29Cond.setKycdknd("MA");
        menu29Cond.setKycd("1");
        result.setMenu29(menu29Dao.selectVO(menu29Cond));

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
     * HC媒体費作成登録
     * @param vo 登録データ
     * @return 登録結果
     * @throws HAMException
     */
    public RegisterHCMediaCreationResult registerHCMediaCreation(RegisterHCMediaCreationVO vo) throws HAMException {

        RegisterHCMediaCreationResult result = new RegisterHCMediaCreationResult();

        // 排他チェック
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
        Tbj06EstimateDetailDAO detailDao = Tbj06EstimateDetailDAOFactory.createTbj06EstimateDetailDAO();
        Tbj05EstimateItemDAO itemDao = Tbj05EstimateItemDAOFactory.createTbj05EstimateItemDAO();
        Tbj04MediaMngEstimateDetailDAO mediaMngEstDtlDao = Tbj04MediaMngEstimateDetailDAOFactory.createTbj04MediaMngEstimateDetailDAO();

        if (vo.getEstseqno() != null && vo.getEstseqno().size() > 0) {
            for (BigDecimal bdEstSeqNo : vo.getEstseqno()) {
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
        }

        if (vo.getDelMediaMngEstDtl() != null && vo.getDelMediaMngEstDtl().size() > 0) {
            for (Tbj04MediaMngEstimateDetailVO delMediaMngEstDtlVo : vo.getDelMediaMngEstDtl()) {
                // 媒体費見積明細管理削除
                mediaMngEstDtlDao.deleteVO(delMediaMngEstDtlVo);
            }
        }

        List<Tbj05EstimateItemVO> updItemVo = vo.getUpdEstimateListItem();
        List<Tbj05EstimateItemVO> insItemVo = vo.getInsEstimateListItem();
        Tbj05EstimateItemDAO tbj05Dao = Tbj05EstimateItemDAOFactory.createTbj05EstimateItemDAO();
        FindHCEstimateListItemDAO findItemDao = FindHCMediaCreationDAOFactory.createFindHCEstimateListItemDao();

        Tbj06EstimateDetailDAO tbj06Dao = Tbj06EstimateDetailDAOFactory.createTbj06EstimateDetailDAO();
        FindEstimateDetailDAO findDetailDao = FindHCMediaCreationDAOFactory.createFindEstimateDetailDao();

        if (insItemVo != null && insItemVo.size() > 0) {
            FindHCEstimateListItemCondition costItemCond = new FindHCEstimateListItemCondition();
            costItemCond.setPhase(vo.getPhase());
            costItemCond.setYearMonth(vo.getYearMonth());

            for (int i = 0; i < insItemVo.size(); i++) {
                // 見積案件管理NO取得
                List<FindHCEstimateListItemVO> itemVo = findItemDao.getEstSeqNo(costItemCond);

                // 見積案件新規登録
                Tbj05EstimateItemVO tbj05Vo = vo.getInsEstimateListItem().get(i);
                tbj05Vo.setESTSEQNO(itemVo.get(0).getESTSEQNO());
                tbj05Dao.insertVO(tbj05Vo);

                // 見積明細管理NO取得
                List<FindEstimateDetailVO> detailVo = findDetailDao.getEstDetailSeqNo();

                // 見積明細新規登録
                Tbj06EstimateDetailVO tbj06Vo = vo.getInsEstimateDetail().get(i);
                tbj06Vo.setESTDETAILSEQNO(detailVo.get(0).getESTDETAILSEQNO());
                tbj06Vo.setESTSEQNO(itemVo.get(0).getESTSEQNO());
                tbj06Dao.insertVO(tbj06Vo);

                // 媒体費見積明細管理登録
                Tbj04MediaMngEstimateDetailVO tbj04Vo = vo.getInsMediaMngEstDtl().get(i);
                if (!tbj04Vo.getMEDIAMNGNO().equals(BigDecimal.valueOf(0))) {
                    tbj04Vo.setESTDETAILSEQNO(detailVo.get(0).getESTDETAILSEQNO());
                    mediaMngEstDtlDao.insertVO(tbj04Vo);
                }
            }
        }

        if (updItemVo != null && updItemVo.size() > 0) {
            for (Tbj05EstimateItemVO tbj05Vo : updItemVo) {

                /** 2015/10/05 請求業務変更対応 HLC S.Fujimoto ADD Start */
                //請求明細書出力日時、請求書出力日時、請求データ出力日時を取得
                Tbj05EstimateItemCondition tbj05Cond = new Tbj05EstimateItemCondition();
                tbj05Cond.setPhase(tbj05Vo.getPHASE());
                tbj05Cond.setCrdate(tbj05Vo.getCRDATE());
                tbj05Cond.setEstseqno(tbj05Vo.getESTSEQNO());
                List<Tbj05EstimateItemVO> findItemVoList = tbj05Dao.selectVO(tbj05Cond);

                tbj05Vo.setLASTOUTPUTDATE(findItemVoList.get(0).getLASTOUTPUTDATE());
                tbj05Vo.setLASTOUTPUTNM(findItemVoList.get(0).getLASTOUTPUTNM());
                tbj05Vo.setOUTPUTFILENM(findItemVoList.get(0).getOUTPUTFILENM());
                tbj05Vo.setBILLDTLLASTOUTPUTDATE(findItemVoList.get(0).getBILLDTLLASTOUTPUTDATE());
                tbj05Vo.setBILLLASTOUTPUTDATE(findItemVoList.get(0).getBILLLASTOUTPUTDATE());
                tbj05Vo.setBILLEXLLASTOUTPUTDATE(findItemVoList.get(0).getBILLEXLLASTOUTPUTDATE());
                /** 2015/10/05 請求業務変更対応 HLC S.Fujimoto ADD End */

                // 見積案件更新
                tbj05Dao.updateVO(tbj05Vo);
            }
        }

        if (vo.getUpdEstimateDetail() != null && vo.getUpdEstimateDetail().size() > 0) {
            for (Tbj06EstimateDetailVO tbj06Vo : vo.getUpdEstimateDetail()) {
                /** 2015/09/11 請求業務変更対応 HLC S.Fujimoto ADD Start */
                //請求先グループ情報取得
                Tbj06EstimateDetailCondition tbj06BillSeqCond = new Tbj06EstimateDetailCondition();
                tbj06BillSeqCond.setEstdetailseqno(tbj06Vo.getESTDETAILSEQNO());
                List<Tbj06EstimateDetailVO> tbj06BillSeqVoList = tbj06Dao.selectVO(tbj06BillSeqCond);

                //更新VOに請求先グループ情報セット
                tbj06Vo.setHCBUMONCDBILL(tbj06BillSeqVoList.get(0).getHCBUMONCDBILL());
                tbj06Vo.setHCBUMONCDBILLSEQNO(tbj06BillSeqVoList.get(0).getHCBUMONCDBILLSEQNO());
                /** 2015/09/11 請求業務変更対応 HLC S.Fujimoto ADD End */

                // 見積明細更新
                tbj06Dao.updateVO(tbj06Vo);
            }
        }

        return result;
    }

    /**
     * 排他チェック
     * @param vo 登録データ
     * @return true：チェックOK、false：チェックNG
     * @throws HAMException
     */
    private boolean checkUpdate(RegisterHCMediaCreationVO vo) throws HAMException {

        // 見積案件/見積明細取得
        FindEstItemDtlDAO itemDtlDao = FindHCMediaCreationDAOFactory.createFindEstItemDtlDao();
        FindEstItemDtlCondition itemDtlCond = new FindEstItemDtlCondition();
        itemDtlCond.setPhase(vo.getPhase());
        itemDtlCond.setYearMonth(vo.getYearMonth());
        itemDtlCond.setEstimateClass(vo.getEstimateClass());
        List<FindEstItemDtlVO> estItemDtlVo = itemDtlDao.selectVO(itemDtlCond);

        // 比較を簡略化するために、HashMapに型を変換
        HashMap<BigDecimal, Date> hm = new HashMap<BigDecimal, Date>();
        for (FindEstItemDtlVO eidVo : estItemDtlVo) {
            hm.put(eidVo.getDtlESTSEQNO(), eidVo.getUPDDATE());
        }

        boolean error = false;

        // 更新対象排他チェック
        if (vo.getUpdEstimateDetail() != null && vo.getUpdEstimateDetail().size() > 0) {
            for (Tbj06EstimateDetailVO edVo : vo.getUpdEstimateDetail()) {
                if (!hm.containsKey(edVo.getESTSEQNO())) {
                    error = true;
                    break;
                }

                if (vo.getLatestUpdDate().before(hm.get(edVo.getESTSEQNO()))) {
                    error = true;
                    break;
                }
            }

            if (error) {
                return false;
            }
        }

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
     * HC見積書、見積CSVファイル作成(媒体)検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindEstMediaReportResult findEstMediaReport(FindEstMediaReportCondition cond) throws HAMException {

        FindEstMediaReportResult result = new FindEstMediaReportResult();

        // 見積案件/見積明細取得
        FindEstItemDtlDAO itemDtlDao = FindHCMediaCreationDAOFactory.createFindEstItemDtlDao();
        FindEstItemDtlCondition itemDtlCond = new FindEstItemDtlCondition();
        itemDtlCond.setPhase(cond.getPhase());
        itemDtlCond.setYearMonth(cond.getYearMonth());
        itemDtlCond.setEstimateClass(cond.getEstimateClass());
        result.setEstItemDtl(itemDtlDao.selectVO(itemDtlCond));

        /** 2015/08/31 請求業務変更対応 S.Fujimoto ADD Start */
        //会社情報取得
        Mbj12CodeDAO codeDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype(HAMConstants.CODETYPE_COMPANYINFO);
        result.setCompanyInfo(codeDao.selectVO(codeCond));

        //仕入消費税計算区分取得
        codeCond.setCodetype(HAMConstants.CODETYPE_CALKBN);
        result.setCalKbn(codeDao.selectVO(codeCond));

        //当月カレンダー取得
        Mbj21CalendarDAO calendarDao = Mbj21CalendarDAOFactory.createMbj21CalendarDAO();
        Mbj21CalendarCondition calendarCond = new Mbj21CalendarCondition();
        calendarCond.setDatakbn(HAMConstants.CALENDAR_DATAKBN_DENTSU);
        calendarCond.setCalendarym(cond.getYearMonth().substring(0, 4) + cond.getYearMonth().substring(5, 7));
        result.setCalendar(calendarDao.selectVO(calendarCond));
        /** 2015/08/31 請求業務変更対応 S.Fujimoto ADD End */

        return result;
    }

    /** 2015/08/31 請求業務変更対応 S.Fujimoto ADD Start */
    /**
     * HM見積書・請求明細書作成(媒体)検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    /** 2016/02/04 請求業務変更対応 HLC K.Oki MOD Start */
    //public FindHMEstimateMediaReportResult findHMEstimateMediaReport(FindHMEstimateMediaReportCondition cond) throws HAMException {
    public FindHMEstimateMediaReportResult findHMEstimateMediaReport(FindHMEstimateMediaReportCondition cond, BigDecimal BillDetailOutput) throws HAMException {
    /** 2016/02/04 請求業務変更対応 HLC K.Oki MOD End */

        FindHMEstimateMediaReportResult result = new FindHMEstimateMediaReportResult();

        /** 2016/01/21 請求業務変更対応 K.Soga ADD Start */
        //出力対象が同一の場合
        if(BillDetailOutput.equals(HAMConstants.REPORT_OUTPUT)){

            //HC部門コード(Fee案件請求用)取得
            cond.setGroupCd(HAMConstants.GROUPCODE0);
            List<Mbj26BillGroupVO> mbj26VoList = EstimateBillUtil.getHCBumonCdBillList(cond.getGroupCd().toString());

            HashMap<String, BigDecimal> outputGrpMap = new HashMap<String, BigDecimal>();

            //請求先Grマスタの件数分ループ処理
            for (Mbj26BillGroupVO mbj26Vo : mbj26VoList) {
                outputGrpMap.put(mbj26Vo.getHCBUMONCDBILL(), BigDecimal.valueOf(0));
            }

            //HM請求書(見積明細出力順SEQNO)集計キー取得
            List<FindHMBillSeqNoVO> billDtlSeqNoSummaryVoList = new ArrayList<FindHMBillSeqNoVO>();
            FindHMBillSeqNoCondition billDtlSeqNoCond = new FindHMBillSeqNoCondition();
            billDtlSeqNoCond.setPhase(cond.getPhase());
            billDtlSeqNoCond.setYearMonth(cond.getYearMonth());
            billDtlSeqNoSummaryVoList = EstimateBillUtil.getHMBillSeqNoSummary(billDtlSeqNoCond);

            /** 2016/04/20 HDX対応 K.Soga ADD Start */
            //原価センタNoが存在しない場合、HC部門コードを更新しない
            Boolean flg = false;

            //請求先Grコード更新チェック
            CheckUpdateHCBumonCdBillDAO chkUpdHCBumonCdBillDao = new CheckUpdateHCBumonCdBillDAO();
            Tbj06EstimateDetailCondition tbj06cond = new Tbj06EstimateDetailCondition();
            tbj06cond.setPhase(cond.getPhase());
            tbj06cond.setCrdate(DateUtil.toDate(cond.getYearMonth().replace("/", "") + "01"));
            List<CheckUpdateHCBumonCdBillVO> ChkUpdHCBumonCdBillVOList = chkUpdHCBumonCdBillDao.checkUpdateHcBumonCdBill(tbj06cond);

            //更新対象の明細が存在する場合
            for(int i = 0; i < ChkUpdHCBumonCdBillVOList.size(); i++){
                //原価センタNo取得
                Mbj09HiyouDAO mbj09dao = new Mbj09HiyouDAO();
                Mbj09HiyouCondition mbj09cond = new Mbj09HiyouCondition();
                mbj09cond.setMediacd(ChkUpdHCBumonCdBillVOList.get(i).getMediaCd());
                mbj09cond.setDcarcd(ChkUpdHCBumonCdBillVOList.get(i).getDCarCd());
                mbj09cond.setPhase(ChkUpdHCBumonCdBillVOList.get(i).getPhase());
                mbj09cond.setTerm(DateUtil.getTerm(cond.getYearMonth()));
                List<Mbj09HiyouVO> mbj09VOList = mbj09dao.selectVO(mbj09cond);
                //原価センタNoが存在しない場合、フラグをtrueに設定(true:更新させない)
                if(mbj09VOList.size() == 0){
                    flg = true;
                }
            }
            /** 2016/04/20 HDX対応 K.Soga ADD Start */

            //原価センタNoが存在しない場合は、HC部門コードを更新しない
            if(!flg){
                //取得した見積案件分ループ処理
                for(int i =0; i < billDtlSeqNoSummaryVoList.size(); i ++){

                    /** 2016/04/18 HDX対応 K.Soga ADD Start */
                    //HC部門コードが存在しない場合、更新しない
                    if(billDtlSeqNoSummaryVoList.get(i).getMBJ26HCBUMONCDBILL().length() == 0 || billDtlSeqNoSummaryVoList.get(i).getHCBUMONCDBILL().length() > 0){
                        continue;
                    }
                    /** 2016/04/18 HDX対応 K.Soga ADD End */

                    cond.setEstSeqNo(billDtlSeqNoSummaryVoList.get(i).getESTSEQNO());

                    //請求先グループ出力順SEQNO更新
                    if (!EstimateBillUtil.updateHCBumonCdBill(billDtlSeqNoSummaryVoList, outputGrpMap, cond.getEstSeqNo(), HAMConstants.MEDIA)){
                        return result;
                    }
                }
            }
        }
        /** 2016/01/21 請求業務変更対応 K.Soga ADD End */

        //HM見積案件取得
        FindHMEstimateMediaReportDAO hmEstimateMediaDao = FindHCMediaCreationDAOFactory.createHMEstimateMediaReportDao();
        FindHMEstimateMediaReportCondition hmEstimateCond = new FindHMEstimateMediaReportCondition();
        hmEstimateCond.setPhase(cond.getPhase());
        hmEstimateCond.setYearMonth(cond.getYearMonth());
        hmEstimateCond.setEstimateClass(cond.getEstimateClass());
        result.setHMEstimateMedia(hmEstimateMediaDao.selectVO(hmEstimateCond));

        //会社情報取得
        Mbj12CodeDAO codeDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype(HAMConstants.CODETYPE_COMPANYINFO);
        result.setCompanyInfo(codeDao.selectVO(codeCond));

        //仕入消費税計算区分取得
        codeCond.setCodetype(HAMConstants.CODETYPE_CALKBN);
        result.setCalKbn(codeDao.selectVO(codeCond));

        /** 2016/01/22 請求業務変更対応 K.Soga ADD Start */
        //HM部門取得
        codeCond.setCodetype(HAMConstants.CODETYPE_HMDIV);
        result.setHmDiv(codeDao.selectVO(codeCond));
        /** 2016/01/22 請求業務変更対応 K.Soga ADD End */

        //当月カレンダー取得
        Mbj21CalendarDAO calendarDao = Mbj21CalendarDAOFactory.createMbj21CalendarDAO();
        Mbj21CalendarCondition calendarCond = new Mbj21CalendarCondition();
        calendarCond.setDatakbn(HAMConstants.CALENDAR_DATAKBN_DENTSU);
        calendarCond.setCalendarym(cond.getYearMonth().substring(0, 4) + cond.getYearMonth().substring(5, 7));
        List<Mbj21CalendarVO> calendarVoList = calendarDao.selectVO(calendarCond);

        //前月算出
        String year = cond.getYearMonth().substring(0, 4);
        String month = cond.getYearMonth().substring(5, 7);
        String newYearMonth = null;

        //1月の場合.
        if (Integer.parseInt(month) == 1) {
            //前年12月にセット
            newYearMonth = String.format("%04d", Integer.parseInt(year) - 1) + String.format("%02d", 12);
        } else {
            //前月にセット.
            newYearMonth = year + String.format("%02d", Integer.parseInt(month) - 1);
        }

        //前月カレンダー取得
        List<Mbj21CalendarVO> prevCalendarVoList = new ArrayList<Mbj21CalendarVO>();
        calendarCond.setCalendarym(newYearMonth);
        prevCalendarVoList = calendarDao.selectVO(calendarCond);

        //取得したカレンダーをマージ
        for (int i = 0; i < prevCalendarVoList.size(); i++) {
            Mbj21CalendarVO prevCalendarVo = prevCalendarVoList.get(i);
            calendarVoList.add(prevCalendarVo);
        }
        result.setCalendar(calendarVoList);

        //費用企画No取得
        Mbj09HiyouDAO hiyouDao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();
        Mbj09HiyouCondition hiyouCond = new Mbj09HiyouCondition();
        result.setHiyou(hiyouDao.selectVO(hiyouCond));

        return result;
    }

    /**
     * HM請求書作成(媒体)検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindHMBillMediaReportResult findHMBillMediaReport(FindHMBillMediaReportCondition cond) throws HAMException {

        FindHMBillMediaReportResult result = new FindHMBillMediaReportResult();

        /** 2016/02/04 請求業務変更対応 HLC K.Oki DEL Start */
        ////HC部門コード(Fee案件請求用)取得
        //List<Mbj26BillGroupVO> mbj26VoList = EstimateBillUtil.getHCBumonCdBillList();
        //
        //HashMap<String, BigDecimal> outputGrpMap = new HashMap<String, BigDecimal>();
        //for (Mbj26BillGroupVO mbj26Vo : mbj26VoList) {
        //    outputGrpMap.put(mbj26Vo.getHCBUMONCDBILL(), BigDecimal.valueOf(0));
        //}
        //
        ////HM請求書(見積明細出力順SEQNO)集計キー取得
        //List<FindHMBillSeqNoVO> billDtlSeqNoSummaryVoList = new ArrayList<FindHMBillSeqNoVO>();
        //FindHMBillSeqNoCondition billDtlSeqNoCond = new FindHMBillSeqNoCondition();
        //billDtlSeqNoCond.setPhase(cond.getPhase());
        //billDtlSeqNoCond.setYearMonth(cond.getYearMonth());
        //billDtlSeqNoSummaryVoList = EstimateBillUtil.getHMBillSeqNoSummary(billDtlSeqNoCond);
        //
        ////請求先グループ出力順SEQNO更新
        //if (!EstimateBillUtil.updateHCBumonCdBill(billDtlSeqNoSummaryVoList, outputGrpMap)) {
        //    return result;
        //}
        /** 2016/02/04 請求業務変更対応 HLC K.Oki DEL End */

        //HM見積案件取得
        FindHMBillMediaReportDAO hmBillMediaDao = FindHCMediaCreationDAOFactory.createHMBillMediaReportDao();
        FindHMBillMediaReportCondition hmBillCond = new FindHMBillMediaReportCondition();
        hmBillCond.setPhase(cond.getPhase());
        hmBillCond.setYearMonth(cond.getYearMonth());
        hmBillCond.setEstimateClass(cond.getEstimateClass());
        result.setHMBillMedia(hmBillMediaDao.selectVO(hmBillCond));

        //HM合計請求書作成(媒体)取得
        FindHMBillTotalMediaReportDAO hmBillTotalMediaDao = FindHCMediaCreationDAOFactory.createFindHMBillTotalMediaReportDao();
        FindHMBillTotalMediaReportCondition hmBillTotalCond = new FindHMBillTotalMediaReportCondition();
        hmBillTotalCond.setPhase(cond.getPhase());
        hmBillTotalCond.setYearMonth(cond.getYearMonth());
        hmBillTotalCond.setEstimateClass(cond.getEstimateClass());
        result.setHMBillTotalMedia(hmBillTotalMediaDao.selectVO(hmBillTotalCond));

        //会社情報取得
        Mbj12CodeDAO codeDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype(HAMConstants.CODETYPE_COMPANYINFO);
        result.setCompanyInfo(codeDao.selectVO(codeCond));

        //仕入消費税計算区分取得
        codeCond.setCodetype(HAMConstants.CODETYPE_CALKBN);
        result.setCalKbn(codeDao.selectVO(codeCond));

        //HM部門取得
        codeCond.setCodetype(HAMConstants.CODETYPE_HMDIV);
        result.setHmDiv(codeDao.selectVO(codeCond));

        //当月カレンダー取得
        Mbj21CalendarDAO calendarDao = Mbj21CalendarDAOFactory.createMbj21CalendarDAO();
        Mbj21CalendarCondition calendarCond = new Mbj21CalendarCondition();
        calendarCond.setDatakbn(HAMConstants.CALENDAR_DATAKBN_DENTSU);
        calendarCond.setCalendarym(cond.getYearMonth().substring(0, 4) + cond.getYearMonth().substring(5, 7));
        List<Mbj21CalendarVO> calendarVoList = calendarDao.selectVO(calendarCond);

        //前月算出
        String year = cond.getYearMonth().substring(0, 4);
        String month = cond.getYearMonth().substring(5, 7);
        String newYearMonth = null;

        //1月の場合.
        if (Integer.parseInt(month) == 1) {
            //前年12月にセット
            newYearMonth = String.format("%04d", Integer.parseInt(year) - 1) + String.format("%02d", 12);
        } else {
            //前月にセット.
            newYearMonth = year + String.format("%02d", Integer.parseInt(month) - 1);
        }

        //前月カレンダー取得
        List<Mbj21CalendarVO> prevCalendarVoList = new ArrayList<Mbj21CalendarVO>();
        calendarCond.setCalendarym(newYearMonth);
        prevCalendarVoList = calendarDao.selectVO(calendarCond);

        //取得したカレンダーをマージ
        for (int i = 0; i < prevCalendarVoList.size(); i++) {
            Mbj21CalendarVO prevCalendarVo = prevCalendarVoList.get(i);
            calendarVoList.add(prevCalendarVo);
        }
        result.setCalendar(calendarVoList);

        //費用企画Noマスタ取得
        Mbj09HiyouDAO hiyouDao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();
        Mbj09HiyouCondition hiyouCond = new Mbj09HiyouCondition();
        result.setHiyou(hiyouDao.selectVO(hiyouCond));

        return result;
    }
    /** 2015/08/31 請求業務変更対応 S.Fujimoto Add End */

    /**
     * 帳票ファイル出力情報登録
     * @param vo 帳票ファイル情報
     * @return 登録結果
     * @throws HAMException
     */
    public RegisterOutputFileInfoResult registerOutputFileInfo(RegisterOutputFileInfoVO vo) throws HAMException {

        RegisterOutputFileInfoResult result = new RegisterOutputFileInfoResult();
        /** 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD Start */
        Tbj05EstimateItemDAO tbj05Dao = Tbj05EstimateItemDAOFactory.createTbj05EstimateItemDAO();
        /** 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD End */

        if (vo.getEstimateItem() != null && vo.getEstimateItem().size() > 0) {
            for (Tbj05EstimateItemVO tbj05Vo : vo.getEstimateItem()) {
                /** 2015/08/31 請求業務変更対応 HLC S.Fujimoto DEL Start */
                //Tbj05EstimateItemDAO tbj05Dao = Tbj05EstimateItemDAOFactory.createTbj05EstimateItemDAO();
                /** 2015/08/31 請求業務変更対応 HLC S.Fujimoto DEL End */

                tbj05Dao.updateOutputInfo(tbj05Vo);
            }
        }

        return result;
    }
}