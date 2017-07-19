package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.common.model.Mbj09HiyouCondition;
import jp.co.isid.ham.common.model.Mbj09HiyouDAO;
import jp.co.isid.ham.common.model.Mbj09HiyouDAOFactory;
import jp.co.isid.ham.common.model.Mbj09HiyouVO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoCondition;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAOFactory;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.constants.HAMConstants;

/**
 * <P>
 * 営業作業台帳ラジオタイムインポート情報検索Managerクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/12/11 HLC S.Fujimoto)<BR>
 * ・JASRAC不具合対応(2016/1/13 HLC K.Soga)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdTime2AccountBookManager {

    /** シングルトンインスタンス */
    private static FindRdTime2AccountBookManager _manager = new FindRdTime2AccountBookManager();

    /** 媒体コード(ラジオタイム) */
    private static final String MEDIA_RADIOTIME = "M05";

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindRdTime2AccountBookManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindRdTime2AccountBookManager getInstance() {
        return _manager;
    }

    /**
     * 営業作業台帳登録用VOを作成
     * @param cond 検索条件
     * @return 営業作業台帳登録用VO
     * @throws HAMException
     */
    public List<Tbj02EigyoDaichoVO> FindRdTime2AccountBook(FindRdTime2AccountBookCondition cond) throws HAMException {

        //既に当月ラジオタイム情報が営業作業台帳にあるかチェック
        Tbj02EigyoDaichoDAO tbj02dao = Tbj02EigyoDaichoDAOFactory.createTbj02EigyoDaichoDAO();
        Tbj02EigyoDaichoCondition tbj02cond = new Tbj02EigyoDaichoCondition();
        tbj02cond.setSeikyuym(DateUtil.toDate(cond.getYearMonth().replace("/", "") + "01"));
        tbj02cond.setMediacd(MEDIA_RADIOTIME);
        List<Tbj02EigyoDaichoVO> tbj02VoList = tbj02dao.selectVO(tbj02cond);

        if (tbj02VoList.size() != 0) {
            throw new HAMException("登録","BJ-W0438");
        }

        //月末日取得
        Calendar calendar = Calendar.getInstance();
        calendar.setTime(tbj02cond.getSeikyuym());  //月初日
        calendar.add(Calendar.MONTH, 1);    //翌月初日
        calendar.add(Calendar.DATE, -1);    //当月末日

        //営業作業台帳登録情報作成
        //初期化
        tbj02VoList.clear();

        //営業作業台帳ラジオタイムインポート情報検索
        FindRdTime2AccountBookDAO dao = FindRdTime2AccountBookDAOFactory.createFindRdTime2AccountBookDAO();
        //開始日付に月初日セット
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM/dd");
        cond.setStartDate(sdf.format(tbj02cond.getSeikyuym()));
        //終了日付に月末日セット
        cond.setEndDate(sdf.format(calendar.getTime()));

        List<FindRdTime2AccountBookVO> voList = dao.findRdTime2AccountBookinfo(cond);

        //取得できない場合、処理終了
        if (voList.size() == 0) {
            return tbj02VoList;
        }

        //営業作業台帳の最大ソート順取得
        //月初日
        tbj02cond.setKikanfrom(tbj02cond.getSeikyuym());
        //月末日
        tbj02cond.setKikanto(calendar.getTime());
        BigDecimal tbj02MaxSortNo = tbj02dao.FindMaxSortNo(tbj02cond).get(0).getSORTNO();

        //月額料金HashMap作成
        Map<BigDecimal, BigDecimal> monthAmtMap = new HashMap<BigDecimal, BigDecimal>();    //合計金額
        Map<BigDecimal, BigDecimal> monthCntMap = new HashMap<BigDecimal, BigDecimal>();    //件数
        Map<BigDecimal, Map<String, BigDecimal>> monthCarMap = new HashMap<BigDecimal, Map<String, BigDecimal>>();    //車種マップ

        for (FindRdTime2AccountBookVO vo : voList) {

            //月額料金の場合
            if (vo.getSALESPRICEDIV().equals(HAMConstants.SALES_PRICE_DIV_MONTLY)) {

                //合計金額
                if (!monthAmtMap.containsKey(vo.getRDSEQNO())) {
                    monthAmtMap.put(vo.getRDSEQNO(), vo.getSALESPRICE());
                    monthCntMap.put(vo.getRDSEQNO(), BigDecimal.valueOf(0));
                } else {
                    //BigDecimal cnt = monthCntMap.get(vo.getRDSEQNO());
                }

                //車種マップ
                Map<String, BigDecimal> monthCarCntMap = monthCarMap.get(vo.getRDSEQNO());
                if (monthCarMap.get(vo.getRDSEQNO()) == null) {
                    monthCarCntMap = new HashMap<String, BigDecimal>();
                    monthCarCntMap.put(vo.getDCARCD(), vo.getCNT());
                    monthCarMap.put(vo.getRDSEQNO(),  monthCarCntMap);
                } else {
                    BigDecimal cnt = monthCarCntMap.get(vo.getDCARCD());
                    if (cnt == null) {
                        cnt = BigDecimal.valueOf(0);
                    }
                    monthCarCntMap.put(vo.getDCARCD(), cnt.add(vo.getCNT()));
                    monthCarMap.put(vo.getRDSEQNO(),  monthCarCntMap);
                }

                //件数
                monthCntMap.put(vo.getRDSEQNO(), monthCntMap.get(vo.getRDSEQNO()).add(vo.getCNT()));
            }
        }

        //月額料金HashMapから1回当たりの単価を取得
        Map<BigDecimal, BigDecimal> monthPerAmtMap = new HashMap<BigDecimal, BigDecimal>();
        for (BigDecimal key : monthAmtMap.keySet()) {
            //金額
            BigDecimal amount = monthAmtMap.get(key);
            //件数
            BigDecimal count = monthCntMap.get(key);
            //車種リスト
            Map<String, BigDecimal> carCntMap = monthCarMap.get(key);

            //単価算出
            BigDecimal unitAmt = BigDecimal.valueOf(0);
            if (carCntMap.size() == 1) {
                //1車種の場合は合計金額を単価とする
                unitAmt = amount;
            } else {
                //単価算出(切り上げ)
                unitAmt = amount.divide(count, 0, BigDecimal.ROUND_UP);
            }

            monthPerAmtMap.put(key, unitAmt);
        }

        //営業作業台帳VO作成
        int i = 0;
        for (FindRdTime2AccountBookVO vo : voList) {

            Tbj02EigyoDaichoVO tbj02vo = new Tbj02EigyoDaichoVO();

            //媒体管理No
            tbj02vo.setMEDIAPLANNO(null);
            //台帳キー
            tbj02vo.setDAICHONO(null);
            //IMPキー
            tbj02vo.setIMPKEY(null);
            //請求年月
            tbj02vo.setSEIKYUYM(DateUtil.toDate(cond.getYearMonth().replace("/", "") + "01"));
            //媒体コード
            tbj02vo.setMEDIACD(MEDIA_RADIOTIME);//ラジオタイム
            //媒体種別コード
            tbj02vo.setMEDIASCD(null);
            //媒体種別名
            tbj02vo.setMEDIASNM(vo.getRDSTATION());//放送局略称
            //系列コード
            tbj02vo.setKEIRETSUCD(vo.getKEIRETSUCD());
            //電通車種コード
            tbj02vo.setDCARCD(vo.getDCARCD());

            //費用計画No、企画No
            List<Mbj09HiyouVO> mbj09VoList = getHiyouInfo(vo, cond);
            if (mbj09VoList == null || mbj09VoList.size() == 0) {
                //取得できない場合
                tbj02vo.setHIYOUNO(null);
                tbj02vo.setKIKAKUNO(null);
            } else {
                //取得できる場合
                tbj02vo.setHIYOUNO(mbj09VoList.get(0).getHIYOUNO());
                tbj02vo.setKIKAKUNO(mbj09VoList.get(0).getKIKAKUNO());
            }

            //キャンペーン名
            tbj02vo.setCAMPAIGN(vo.getPROGRAMNM());
            //内容費目
            tbj02vo.setNAIYOHIMOKU(vo.getMEDIANM());
            //スペース（新聞のみ）
            tbj02vo.setSPACE(null);
            //朝夕（新聞のみ）
            tbj02vo.setNPDIVISION(null);
            //掲載版（新聞のみ）
            tbj02vo.setPUBLISHVER(null);
            //記雑区分（新聞のみ）
            tbj02vo.setSYMBOLDIVISION(null);
            //掲載面（新聞のみ）
            tbj02vo.setPOSTEDSURFACE(null);
            //単位（新聞のみ）
            tbj02vo.setUNIT(null);
            //契約区分（新聞のみ）
            tbj02vo.setCONTRACTDIVISION(null);

            /* 2016/1/13 JASRAC不具合対応 HLC K.Soga MOD Start */
            //期間開始
            //月初日をセット
//            Date startDate = DateUtil.toDate(cond.getYearMonth().replace("/", "") + "01");
//            if (startDate.compareTo(vo.getSTARTDATE()) < 0) {
//                startDate = vo.getSTARTDATE();
//            }
            //期間開始
            //月初日をセット
            Date startDate = vo.getSTARTDATE();

            //月初日＜放送開始日の場合、放送開始日を期間開始日にセット
            if (startDate.compareTo(DateUtil.toDate(cond.getStartDate().replace("/", ""))) < 0) {
                startDate = DateUtil.toDate(cond.getStartDate().replace("/", ""));
            }
            /* 2016/1/13 JASRAC不具合対応 HLC K.Soga MOD End */

            tbj02vo.setKIKANFROM(startDate);


            /* 2016/1/13 JASRAC不具合対応 HLC K.Soga MOD Start */
            //期間終了
            //月末日取得
//            calendar.setTime(tbj02vo.getKIKANFROM());
//            calendar.add(Calendar.MONTH, 1);    //翌月初日
//            calendar.add(Calendar.DATE, -1);    //当月末日
//            Date endDate = calendar.getTime();
//            if (vo.getENDDATE().compareTo(endDate) < 0) {
//                endDate = vo.getENDDATE();
//            }

            //期間終了
            //月末日取得
            Date endDate = vo.getENDDATE();

            //放送終了日＜月末日の場合、放送終了日を期間終了日にセット
            if (endDate.compareTo(DateUtil.toDate(cond.getEndDate().replace("/", ""))) > 0) {
                endDate = DateUtil.toDate(cond.getEndDate().replace("/", ""));
            }
            /* 2016/1/13 JASRAC不具合対応 HLC K.Soga MOD End */

            tbj02vo.setKIKANTO(endDate);

            //原価入力フラグ
            tbj02vo.setGENKAFLG(null);

            //グロス金額
            if (vo.getSALESPRICEDIV().equals(HAMConstants.SALES_PRICE_DIV_SECOND20)) {
                //20秒単価
                tbj02vo.setGROSS(vo.getSALESPRICE().multiply(vo.getCNT()));
            } else if (vo.getSALESPRICEDIV().equals(HAMConstants.SALES_PRICE_DIV_MONTLY)) {
                //残額
                BigDecimal amt = monthAmtMap.get(vo.getRDSEQNO());
                //単価
                BigDecimal unitAmt = monthPerAmtMap.get(vo.getRDSEQNO());
                //車種リスト
                Map<String, BigDecimal> carMap = monthCarMap.get(vo.getRDSEQNO());

                if (carMap.size() != 1) {
                        unitAmt = unitAmt.multiply(carMap.get(vo.getDCARCD()));
                }

            //残額－単価＜単価の場合
            if (unitAmt.compareTo(amt) > 0) {
                unitAmt = amt;
            }
                tbj02vo.setGROSS(unitAmt);
                monthAmtMap.put(vo.getRDSEQNO(), amt.subtract(unitAmt));
            }

            //電通値引率
            tbj02vo.setDNEBIKIRITSU(BigDecimal.valueOf(17));
            //電通値引額
            //※グロス金額の17%、切捨て
            BigDecimal discount = tbj02vo.getGROSS().multiply(tbj02vo.getDNEBIKIRITSU().divide(BigDecimal.valueOf(100).setScale(0, BigDecimal.ROUND_DOWN)));
            tbj02vo.setDNEBIKIGAKU(discount);
            //H新モデルコスト
            tbj02vo.setHMCOST(tbj02vo.getGROSS().subtract(discount));
            //営業申込利益率
            tbj02vo.setAPLRIEKIRITSU(BigDecimal.valueOf(0));
            //営業申込利益額
            tbj02vo.setAPLRIEKIGAKU(BigDecimal.valueOf(0));
            //媒体社払金額
            tbj02vo.setMEDIAHARAI(tbj02vo.getGROSS());
            //媒体マージン率
            tbj02vo.setMEDIAMARGINRITSU(tbj02vo.getDNEBIKIRITSU());
            //媒体マージン額
            tbj02vo.setMEDIAMARGINGAKU(tbj02vo.getDNEBIKIGAKU());
            //媒体原価
            tbj02vo.setMEDIAGENKA(tbj02vo.getHMCOST());
            //取扱利益額
            tbj02vo.setTORIRIEKI(BigDecimal.valueOf(0));
            //通常利益配分額
            tbj02vo.setRIEKIHAIBUN(BigDecimal.valueOf(0));
            //通常内勤利益額
            //※グロス金額の2%、切捨て
            tbj02vo.setNAIKINRIEKI(tbj02vo.getGROSS().multiply(BigDecimal.valueOf(2).divide(BigDecimal.valueOf(100).setScale(0, BigDecimal.ROUND_DOWN))));
            //振替利益配分額
            tbj02vo.setFURIKAERIEKI(tbj02vo.getNAIKINRIEKI());
            //営業要因額
            tbj02vo.setEIGYOYOIN(BigDecimal.valueOf(0));
            //振替利益配分額2
            tbj02vo.setFURIKAERIEKI2(null);
            //テレビタイム媒体社払単価
            tbj02vo.setTVTMEDIATANKA(null);
            //テレビタイムHM単価
            tbj02vo.setTVTHMTANKA(null);
            //色刷料（新聞のみ）
            tbj02vo.setCOLORFEE(null);
            //指定料（新聞のみ）
            tbj02vo.setDESIGNATIONFEE(null);
            //二連版料（新聞のみ）
            tbj02vo.setDOUBLEFEE(null);
            //組替料（新聞のみ）
            tbj02vo.setRECLASSIFICATIONFEE(null);
            //変形スペース料（新聞のみ）
            tbj02vo.setSPACEFEE(null);
            //スプリットラン料（新聞のみ）
            tbj02vo.setSPLITRUNFEE(null);
            //依頼先（新聞のみ）
            tbj02vo.setREQUESTDESTINATION(null);
            //放送日
            tbj02vo.setBRDDATE(null);
            //備考
            tbj02vo.setBIKO(null);
            //請求対象フラグ
            tbj02vo.setSEIKYUFLG("0");
            //日付設定(ラジオタイムのみ)
            tbj02vo.setCPDATE(getOnAirDay(vo, tbj02vo));
            //秒数(ラジオタイムのみ)
            tbj02vo.setBRDSEC(vo.getSECOND());
            //受注ファイル出力フラグ（新聞のみ）
            tbj02vo.setFILEOUTFLG("2");//未作成

            /* 2015/11/24 JASRAC対応 HLC K.Soga MOD Start */
            //掲載日
//            tbj02vo.setAPPEARANCEDATE(startDate);
            tbj02vo.setAPPEARANCEDATE(DateUtil.toDate(cond.getStartDate().replace("/", "")));

            //期間開始
            tbj02vo.setKIKANFROM(DateUtil.toDate(cond.getStartDate().replace("/", "")));

            //期間終了
            tbj02vo.setKIKANTO(DateUtil.toDate(cond.getEndDate().replace("/", "")));
            /* 2015/11/24 JASRAC対応 HLC K.Soga MOD End */

            //ソート順
            tbj02vo.setSORTNO(tbj02MaxSortNo.add(BigDecimal.valueOf(i + 1)));
            i++;
            //データ作成者
            tbj02vo.setCRTNM(cond.getUpdNm());
            //作成プログラム
            tbj02vo.setCRTAPL(cond.getUpdApl());
            //作成担当者ID
            tbj02vo.setCRTID(cond.getUpdId());
            //データ更新者
            tbj02vo.setUPDNM(cond.getUpdNm());
            //更新プログラム
            tbj02vo.setUPDAPL(cond.getUpdApl());
            //更新担当者ID
            tbj02vo.setUPDID(cond.getUpdId());

            //追加
            tbj02VoList.add(tbj02vo);
        }

        return tbj02VoList;
    }

    /**
     * 費用情報取得
     * @param vo 営業作業台帳ラジオタイムインポート情報検索VO
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    private List<Mbj09HiyouVO> getHiyouInfo(FindRdTime2AccountBookVO vo, FindRdTime2AccountBookCondition cond) throws HAMException {

        //費用計画No取得
        Mbj09HiyouDAO mbj09dao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();
        Mbj09HiyouCondition mbj09cond = new Mbj09HiyouCondition();
        mbj09cond.setDcarcd(vo.getDCARCD());
        mbj09cond.setMediacd(MEDIA_RADIOTIME);
        mbj09cond.setPhase(cond.getPhase());
        mbj09cond.setTerm(DateUtil.getTerm(cond.getYearMonth()));
        return mbj09dao.selectVO(mbj09cond);
    }

    /**
     * 放送日取得
     * @param vo 営業作業台帳登録用VO
     * @param tbj02vo 営業作業台帳VO
     * @param dayCnt 日数
     * @return 放送日(文字列)
     */
    private String getOnAirDay(FindRdTime2AccountBookVO vo, Tbj02EigyoDaichoVO tbj02vo) {

        //"MM/"を生成
        StringBuilder sb = new StringBuilder();
        Integer month = Integer.parseInt(DateUtil.toString(tbj02vo.getKIKANFROM()).substring(4, 6));
        sb.append(month.toString() + "/");

        Calendar calendar = Calendar.getInstance();
        int weekday = 0;

        //期間開始日～期間終了日の日付リスト作成
        List<Integer> dayList = new ArrayList<Integer>();
        for (int i = 0; i <= DateUtil.getTermDays(tbj02vo.getKIKANFROM(), tbj02vo.getKIKANTO()); i++) {

            //日付作成
            calendar.setTime(tbj02vo.getKIKANFROM());
            calendar.add(Calendar.DATE, i);

            //曜日を取得(0=Sun..6=Sat)
            weekday = calendar.get(Calendar.DAY_OF_WEEK) - 1;

            //曜日が放送日の場合、リストに追加
            if (vo.getONAIRDAY().substring(weekday, weekday + 1).equals("1")) {
                dayList.add(calendar.get(Calendar.DATE));
            }
        }

        //開始日付
        Integer startDate = 0;
        //終了日付
        Integer endDate = 0;

        //取得した日付リストをループ処理
        for (int i = 0; i < dayList.size(); i++) {

            //1件目
            if (i == 0) {
                startDate = dayList.get(0);
                sb.append(startDate.toString());
                continue;
            }

            //連続する日付の場合、終了日付にセット
            if (dayList.get(i).equals(startDate + 1) || dayList.get(i).equals(endDate + 1)) {
                endDate = dayList.get(i);
                continue;
            } else {
                //連続する日付の場合、"-"で結合
                if (endDate != 0 && startDate != endDate) {
                    sb.append("-");
                    sb.append(endDate.toString());
                }

                //連続しない日付を","、および開始日付で結合
                sb.append(",");
                startDate = dayList.get(i);
                sb.append(startDate.toString());
                endDate = 0;
            }
        }

        //終了日付と最後のデータが一致する場合、"-"で結合
        if (endDate.equals(dayList.get(dayList.size() - 1))) {
            sb.append("-");
            sb.append(dayList.get(dayList.size() - 1));
        }

        return sb.toString();
    }

}
