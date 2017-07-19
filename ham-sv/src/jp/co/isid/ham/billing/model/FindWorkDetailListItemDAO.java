package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj09Hiyou;
import jp.co.isid.ham.integ.tbl.Mbj15CrClass;
import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * 制作費明細書出力一覧取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/5 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class FindWorkDetailListItemDAO extends AbstractRdbDao {

    FindWorkDetailCondition _condition = null;

    /** getSelectSQLで発行するSQLのモード() */
    /** 制作費管理NO */
    private static final int MODE_EQUENCENO = 1;
    /** 見積明細 */
    private static final int MODE_MEISAILIST = 2;
    /** 制作原価 */
    private static final int MODE_SEISAKUGENKA = 3;
    /** SQLモード */
    private int _SelSqlMode = 0;

    /** 制作費明細書出力一覧(制作費取込)取得VOリスト */
    private List<FindWorkDetailGenkaVO> _seisakuhiList = new ArrayList<FindWorkDetailGenkaVO>();
    /** 制作費明細書出力一覧取得VOリスト */
    private List<FindWorkDetailListItemVO> _listItem = new ArrayList<FindWorkDetailListItemVO>();

    /** 上期 */
    private static final String FIRST_TERM = "0";
//    private static final String FIRST_TERM = "上";
    /** 下期 */
    private static final String SECOND_TERM = "1";
//    private static final String SECOND_TERM = "下";
    /** 契約 */
    private static final String ZEIKBN_KEIYAKU = "05";
    /** 広告制作費 */
    private static final String MEDIACD_KOKOKU = "M30";
    /** 契約関連 */
    private static final String MEDIACD_KEIYAK = "M32";

    /** 年算出係数(ﾌｪｲｽﾞ+1923が西暦年) */
    private static final int PHASE_NEN_KEISU = 1923;

    /**
     * デフォルトコンストラクタ
     */
    public FindWorkDetailListItemDAO(){
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * テーブル列名を返します。
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {

        if (_SelSqlMode == MODE_EQUENCENO) {

            return new String[]{
                    Tbj22SeisakuhiSs.SEQUENCENO
                    };
        } else if (_SelSqlMode == MODE_MEISAILIST) {

            return new String[]{
                    Tbj07EstimateCreate.SEQUENCENO
                    ,Tbj06EstimateDetail.ESTDETAILSEQNO
                    ,Tbj06EstimateDetail.PHASE
                    ,Tbj06EstimateDetail.CRDATE
                    ,Tbj06EstimateDetail.ESTSEQNO
                    ,Tbj06EstimateDetail.SORTNO
                    ,Tbj06EstimateDetail.PRODUCTCD
                    ,Tbj06EstimateDetail.PRODUCTNM
                    ,Tbj06EstimateDetail.PRODUCTNMSUB
                    ,Tbj06EstimateDetail.MEDIACLASSCD
                    ,Tbj06EstimateDetail.MEDIACD
                    ,Tbj06EstimateDetail.BUSINESSCLASSCD
                    ,Tbj06EstimateDetail.BUSINESSCD
                    ,Tbj06EstimateDetail.TEKIYOU
                    ,Tbj06EstimateDetail.OPERATIONDATE
                    ,Tbj06EstimateDetail.SIZECD
                    ,Tbj06EstimateDetail.SIZE
                    ,Tbj06EstimateDetail.SUURYOU
                    ,Tbj06EstimateDetail.UNITGROUPCD
                    ,Tbj06EstimateDetail.UNITGROUPNM
                    ,Tbj06EstimateDetail.TANKA
                    ,Tbj06EstimateDetail.HYOUJUN
                    ,Tbj06EstimateDetail.NEBIKI
                    ,Tbj06EstimateDetail.MITUMORI
                    ,Tbj06EstimateDetail.KAZEI
                    ,Tbj06EstimateDetail.SYOUHIZEI
                    ,Tbj06EstimateDetail.GOUKEI
                    ,Tbj06EstimateDetail.CALKBN
                    ,Tbj06EstimateDetail.NOUNYUUFLG
                    ,Tbj06EstimateDetail.DEKIDAKAFLG
                    ,Tbj06EstimateDetail.OUTPUTGROUP
                    ,Tbj06EstimateDetail.CRTDATE
                    ,Tbj06EstimateDetail.CRTNM
                    ,Tbj06EstimateDetail.CRTAPL
                    ,Tbj06EstimateDetail.CRTID
                    ,Tbj06EstimateDetail.UPDDATE
                    ,Tbj06EstimateDetail.UPDNM
                    ,Tbj06EstimateDetail.UPDAPL
                    ,Tbj06EstimateDetail.UPDID
                    };
        } else if (_SelSqlMode == MODE_SEISAKUGENKA) {

            return new String[]{
                    Tbj22SeisakuhiSs.DCARCD
                    ,Tbj22SeisakuhiSs.PHASE
                    ,Tbj22SeisakuhiSs.CRDATE
                    ,Tbj22SeisakuhiSs.SEQUENCENO
                    ,Tbj22SeisakuhiSs.CLASSDIV
                    ,Tbj22SeisakuhiSs.SORTNO
                    ,Tbj22SeisakuhiSs.CLASSCD
                    ,Tbj22SeisakuhiSs.EXPCD
                    ,Tbj22SeisakuhiSs.EXPENSE
                    ,Tbj22SeisakuhiSs.DETAIL
                    ,Tbj22SeisakuhiSs.KIKANS
                    ,Tbj22SeisakuhiSs.KIKANE
                    ,Tbj22SeisakuhiSs.CONTRACTDATE
                    ,Tbj22SeisakuhiSs.CONTRACTTERM
                    ,Tbj22SeisakuhiSs.SEIKYU
                    ,Tbj22SeisakuhiSs.ORDERNO
                    ,Tbj22SeisakuhiSs.PAY
                    ,Tbj22SeisakuhiSs.USERNAME
                    ,"NVL(" + Tbj22SeisakuhiSs.GETMONEY + ", 0) " + Tbj22SeisakuhiSs.GETMONEY
                    ,"NVL(" + Tbj22SeisakuhiSs.GETCONF + ", '0') " + Tbj22SeisakuhiSs.GETCONF
                    ,"NVL(" + Tbj22SeisakuhiSs.PAYMONEY + ", 0) " + Tbj22SeisakuhiSs.PAYMONEY
                    ,"NVL(" + Tbj22SeisakuhiSs.PAYCONF + ", '0') " + Tbj22SeisakuhiSs.PAYCONF
                    ,"NVL(" + Tbj22SeisakuhiSs.ESTMONEY + ", 0) " + Tbj22SeisakuhiSs.ESTMONEY
                    ,"NVL(" + Tbj22SeisakuhiSs.CLMMONEY + ", 0) " + Tbj22SeisakuhiSs.CLMMONEY
                    ,Tbj22SeisakuhiSs.DELIVERDAY
                    ,Tbj22SeisakuhiSs.SETMONTH
                    ,Tbj22SeisakuhiSs.DIVCD
                    ,"NVL(" + Tbj22SeisakuhiSs.GROUPCD + ", 0) " + Tbj22SeisakuhiSs.GROUPCD
                    ,"NVL(" + Tbj22SeisakuhiSs.STKYKNO + ", '') " + Tbj22SeisakuhiSs.STKYKNO
                    ,"NVL(" + Tbj22SeisakuhiSs.EGTYKFLG + ", 0) " + Tbj22SeisakuhiSs.EGTYKFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.INPUTTNTCD + ", '') " + Tbj22SeisakuhiSs.INPUTTNTCD
                    ,Tbj22SeisakuhiSs.NOTE
                    ,"NVL(" + Tbj22SeisakuhiSs.CLASSCDFLG + ", '0') " + Tbj22SeisakuhiSs.CLASSCDFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.EXPCDFLG + ", '0') " + Tbj22SeisakuhiSs.EXPCDFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.EXPENSEFLG + ", '0') " + Tbj22SeisakuhiSs.EXPENSEFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.DETAILFLG + ", '0') " + Tbj22SeisakuhiSs.DETAILFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.KIKANSFLG + ", '0') " + Tbj22SeisakuhiSs.KIKANSFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.KIKANEFLG + ", '0') " + Tbj22SeisakuhiSs.KIKANEFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.CONTRACTDATEFLG + ", '0') " + Tbj22SeisakuhiSs.CONTRACTDATEFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.CONTRACTTERMFLG + ", '0') " + Tbj22SeisakuhiSs.CONTRACTTERMFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.SEIKYUFLG + ", '0') " + Tbj22SeisakuhiSs.SEIKYUFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.ORDERNOFLG + ", '0') " + Tbj22SeisakuhiSs.ORDERNOFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.PAYFLG + ", '0') " + Tbj22SeisakuhiSs.PAYFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.USERNAMEFLG + ", '0') " + Tbj22SeisakuhiSs.USERNAMEFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.GETMONEYFLG + ", '0') " + Tbj22SeisakuhiSs.GETMONEYFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.PAYMONEYFLG + ", '0') " + Tbj22SeisakuhiSs.PAYMONEYFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.ESTMONEYFLG + ", '0') " + Tbj22SeisakuhiSs.ESTMONEYFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.CLMMONEYFLG + ", '0') " + Tbj22SeisakuhiSs.CLMMONEYFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.DELIVERDAYFLG + ", '0') " + Tbj22SeisakuhiSs.DELIVERDAYFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.SETMONTHFLG + ", '0') " + Tbj22SeisakuhiSs.SETMONTHFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.DIVISIONFLG + ", '0') " + Tbj22SeisakuhiSs.DIVISIONFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.GROUPCDFLG + ", '0') " + Tbj22SeisakuhiSs.GROUPCDFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.STKYKNOFLG + ", '0') " + Tbj22SeisakuhiSs.STKYKNOFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.INPUTTNTCDFLG + ", '0') " + Tbj22SeisakuhiSs.INPUTTNTCDFLG
                    ,"NVL(" + Tbj22SeisakuhiSs.NOTEFLG + ", '0') " + Tbj22SeisakuhiSs.NOTEFLG
                    ,Tbj22SeisakuhiSs.CRTDATE
                    ,Tbj22SeisakuhiSs.CRTNM
                    ,Tbj22SeisakuhiSs.CRTAPL
                    ,Tbj22SeisakuhiSs.CRTID
                    ,Tbj22SeisakuhiSs.UPDDATE
                    ,Tbj22SeisakuhiSs.UPDNM
                    ,Tbj22SeisakuhiSs.UPDAPL
                    ,Tbj22SeisakuhiSs.UPDID
                    ,Tbj22SeisakuhiSs.GETTIME
                    ,Tbj22SeisakuhiSs.TIMSTMPSS
                    ,Tbj22SeisakuhiSs.UPDAPLSS
                    ,Tbj22SeisakuhiSs.UPDIDSS
                    ,Mbj09Hiyou.HIYOUNO
            };
        }

        return null;
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {

        StringBuffer tbl = new StringBuffer();

        if (_SelSqlMode == MODE_EQUENCENO) {

            tbl.append(Tbj22SeisakuhiSs.TBNAME + " DA,");
            tbl.append(" (SELECT ");
            tbl.append(    Mbj15CrClass.CLASSCD + ",");
            tbl.append(    Mbj15CrClass.CLASSNM);
            tbl.append(" FROM ");
            tbl.append(    Mbj15CrClass.TBNAME);
            tbl.append(" WHERE ");
            tbl.append(    Mbj15CrClass.DATEFROM);
            tbl.append("   <= TO_DATE('" + KikanFromPhaseGet(_condition.getPhase()).get(0) + "', 'YYYY/MM/DD')");
            tbl.append("   AND ");
            tbl.append(    Mbj15CrClass.DATETO);
            tbl.append("   >= TO_DATE('" + KikanFromPhaseGet(_condition.getPhase()).get(1) + "', 'YYYY/MM/DD')");
            tbl.append(" ) CL,");
            tbl.append(  Mbj16CrExpence.TBNAME + " EX,");
            tbl.append(  Mbj17CrDivision.TBNAME + " DV,");
            tbl.append(  Mbj26BillGroup.TBNAME + " BG");


        } else if (_SelSqlMode == MODE_MEISAILIST) {

            tbl.append(Tbj06EstimateDetail.TBNAME + " LEFT JOIN");
            tbl.append(" (SELECT ");
            tbl.append(    "*");
            tbl.append("  FROM ");
            tbl.append(     Tbj07EstimateCreate.TBNAME + ",");
            tbl.append(     Tbj22SeisakuhiSs.TBNAME);
            tbl.append("  WHERE ");
            tbl.append(     Tbj07EstimateCreate.SEQUENCENO + " IN ");
            tbl.append(setSQLseqList());
            tbl.append("    AND ");
            tbl.append("    UPPER(" + Tbj07EstimateCreate.DCARCD + ") = '" + _condition.getDCarCd() + "' AND ");
            tbl.append(     Tbj07EstimateCreate.PHASE + " = '" + _condition.getPhase() + "' AND ");
            tbl.append(     Tbj07EstimateCreate.CRDATE + " = TO_DATE('" + _condition.getCrDate() + "', 'YYYY/MM') AND ");
            tbl.append("    UPPER(" + Tbj07EstimateCreate.DCARCD + ") = UPPER(" + Tbj22SeisakuhiSs.DCARCD + ") AND ");
            tbl.append(     Tbj07EstimateCreate.PHASE + " = " + Tbj22SeisakuhiSs.PHASE + " AND ");
            tbl.append(     Tbj07EstimateCreate.CRDATE + " = " + Tbj22SeisakuhiSs.CRDATE + " AND ");
            tbl.append(     Tbj07EstimateCreate.SEQUENCENO + " = " + Tbj22SeisakuhiSs.SEQUENCENO);
            tbl.append("  ORDER BY ");
            tbl.append(     Tbj22SeisakuhiSs.SORTNO);
            tbl.append("  ) ");
            tbl.append("  PH94 ON " + Tbj06EstimateDetail.ESTDETAILSEQNO + " = ");
            tbl.append("  PH94." + Tbj07EstimateCreate.ESTDETAILSEQNO);
        } else if (_SelSqlMode == MODE_SEISAKUGENKA) {

            tbl.append(Tbj22SeisakuhiSs.TBNAME + ",");
            tbl.append(" (SELECT *");
            tbl.append("  FROM ");
            tbl.append(     Mbj09Hiyou.TBNAME);
            tbl.append("  WHERE ");
            tbl.append("    UPPER(" + Mbj09Hiyou.DCARCD + ") = '" + _condition.getDCarCd() + "' AND ");
            tbl.append(     Mbj09Hiyou.PHASE + " = '" + _condition.getPhase() + "' AND ");
            tbl.append(     Mbj09Hiyou.TERM + " = '" + termGet(_condition.getCrDate()) + "' AND ");

            if (_condition.getDivCd().equals(ZEIKBN_KEIYAKU)) {
                // 契約
                tbl.append( Mbj09Hiyou.MEDIACD + " = '" + MEDIACD_KEIYAK + "' ");
            } else {
                // その他
                tbl.append( Mbj09Hiyou.MEDIACD + " = '" + MEDIACD_KOKOKU + "' ");
            }
            tbl.append(" ) ");
        }

        return tbl.toString();
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します。
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        StringBuffer sql = new StringBuffer();

        if (_SelSqlMode == MODE_EQUENCENO) {

            sql.append("SELECT ");
            //全項目を取得
            for (int i = 0; i < getTableColumnNames().length; i++){
                sql.append(getTableColumnNames()[i]);
                if(i < getTableColumnNames().length - 1){
                    sql.append(", ");
                }
            }

            sql.append(" FROM ");
            sql.append(getTableName());

            sql.append(" WHERE ");
            sql.append("   DA." + Tbj22SeisakuhiSs.CLASSCD);
            sql.append("   = ");
            sql.append("   CL." + Mbj15CrClass.CLASSCD + "(+) AND ");
            sql.append("   DA." + Tbj22SeisakuhiSs.CLASSDIV);
            sql.append("   = ");
            sql.append("   EX." + Mbj16CrExpence.CLASSDIV + "(+) AND ");
            sql.append("   DA." + Tbj22SeisakuhiSs.EXPCD);
            sql.append("   = ");
            sql.append("   EX." + Mbj16CrExpence.EXPCD + "(+) AND ");
            sql.append("   DA." + Tbj22SeisakuhiSs.DIVCD);
            sql.append("   = ");
            sql.append("   DV." + Mbj17CrDivision.DIVCD + "(+) AND ");
            sql.append("   DA." + Tbj22SeisakuhiSs.GROUPCD);
            sql.append("   = ");
            sql.append("   BG." + Mbj26BillGroup.GROUPCD + "(+) AND ");
            sql.append("   EX." + Mbj16CrExpence.DATEFROM);
            sql.append("   <= TO_DATE('" + KikanFromPhaseGet(_condition.getPhase()).get(0) + "', 'YYYY/MM/DD') AND ");
            sql.append("   EX." + Mbj16CrExpence.DATETO);
            sql.append("   >= TO_DATE('" + KikanFromPhaseGet(_condition.getPhase()).get(1) + "', 'YYYY/MM/DD') AND ");
            sql.append("   DA." + Tbj22SeisakuhiSs.PHASE);
            sql.append("   = ");
            sql.append(    "'" + _condition.getPhase() + "' AND ");
            sql.append("   DA." + Tbj22SeisakuhiSs.CRDATE);
            sql.append("   = TO_DATE('" + _condition.getCrDate() + "', 'YYYY/MM') AND ");
            sql.append("   DA." + Tbj22SeisakuhiSs.DCARCD);
            sql.append("   = ");
            sql.append(    "'" + _condition.getDCarCd() + "' AND ");
            sql.append("   DA." + Tbj22SeisakuhiSs.DIVCD);
            sql.append("   = ");
            sql.append(    "'" + _condition.getDivCd() + "' AND ");
            sql.append("   DA." + Tbj22SeisakuhiSs.GROUPCD);
            sql.append("   = ");
            if (_condition.getGroupCd() == null) {
                sql.append(    "'' AND ");
            } else {
                sql.append(    "'" + _condition.getGroupCd() + "' AND ");
            }
            sql.append("   DA." + Tbj22SeisakuhiSs.CLASSDIV);
            sql.append("   = ");
            sql.append(    "'0'");

            sql.append(" ORDER BY ");
            sql.append("   DA." + Tbj22SeisakuhiSs.SORTNO);

        } else if (_SelSqlMode == MODE_MEISAILIST) {

            sql.append("SELECT ");
            //全項目を取得
            for (int i = 0; i < getTableColumnNames().length; i++){
                sql.append(getTableColumnNames()[i]);
                if(i < getTableColumnNames().length - 1){
                    sql.append(", ");
                }
            }

            sql.append(" FROM ");
            sql.append(getTableName());

            sql.append(" WHERE ");
            sql.append(    Tbj06EstimateDetail.ESTSEQNO + " = '" + _condition.getEstSeqNo() + "' AND ");
            sql.append(    Tbj06EstimateDetail.PHASE + " = '" + _condition.getPhase() + "' AND ");
            sql.append(    Tbj06EstimateDetail.CRDATE + " = TO_DATE('" + _condition.getCrDate() + "', 'YYYY/MM') ");

            sql.append(" ORDER BY ");
            sql.append(    Tbj06EstimateDetail.SORTNO + ",");
            sql.append("   PH94." + Tbj22SeisakuhiSs.SORTNO + ",");
            sql.append(    Tbj06EstimateDetail.OUTPUTGROUP);
        } else if (_SelSqlMode == MODE_SEISAKUGENKA) {

            sql.append("SELECT ");
            //全項目を取得
            for (int i = 0; i < getTableColumnNames().length; i++){
                sql.append(getTableColumnNames()[i]);
                if(i < getTableColumnNames().length - 1){
                    sql.append(", ");
                }
            }

            sql.append(" FROM ");
            sql.append(getTableName());

            sql.append(" WHERE ");
            sql.append(    Tbj22SeisakuhiSs.SEQUENCENO + " IN ");
            sql.append(setSQLseqList());
            sql.append("   AND ");
            sql.append(    Tbj22SeisakuhiSs.CRDATE + " = TO_DATE('" + _condition.getCrDate() + "', 'YYYY/MM') AND ");
            sql.append("   UPPER(" + Tbj22SeisakuhiSs.DCARCD + ") = '" + _condition.getDCarCd() + "' AND ");
            sql.append("   UPPER(" + Tbj22SeisakuhiSs.DCARCD + ") = UPPER(" + Mbj09Hiyou.DCARCD + "(+)) AND ");
            sql.append(    Tbj22SeisakuhiSs.DIVCD + " = " + _condition.getDivCd());
            sql.append(" ORDER BY ");
            sql.append(    Tbj22SeisakuhiSs.SORTNO);
        }

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、見積明細を取得します。
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindWorkDetailListItemVO> getWorkDetailListItem(FindWorkDetailCondition condition) throws HAMException{
        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        try
        {
            /*--------------------------------------------------
              選択された案件より、制作費管理Noを取得
             -------------------------------------------------*/
            _SelSqlMode = MODE_EQUENCENO;
            _condition = condition;

            super.setModel(new FindWorkDetailGenkaVO());
            _seisakuhiList = (List<FindWorkDetailGenkaVO>) super.find();

            /*---------------------------------------
              HC見積明細取得(TPH5C_SORTNO順)
             --------------------------------------*/
            if (_seisakuhiList.size() > 0) {
                _SelSqlMode = MODE_MEISAILIST;

                super.setModel(new FindWorkDetailListItemVO());
                _listItem = (List<FindWorkDetailListItemVO>) super.find();

                if (_listItem.size() > 0) {

                    for (int i = 0; i < _listItem.size(); i++) {

                        if (_listItem.get(i).get(Tbj07EstimateCreate.SEQUENCENO) == null) {

                            // nullなら制作費管理NOに-1を設定
                            _listItem.get(i).set(Tbj07EstimateCreate.SEQUENCENO, new BigDecimal(-1));
                        }
                    }
                }
                return _listItem;
            }

            return new ArrayList<FindWorkDetailListItemVO>();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 指定した条件で検索を行い、制作原価を取得します。
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindWorkDetailGenkaVO> getWorkGenka(FindWorkDetailCondition condition) throws HAMException{
        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        try
        {
            /*---------------------------------------
              制作原価取得
             --------------------------------------*/
            if (_seisakuhiList.size() > 0) {
                  _SelSqlMode = MODE_SEISAKUGENKA;

                super.setModel(new FindWorkDetailGenkaVO());
                _seisakuhiList = (List<FindWorkDetailGenkaVO>) super.find();

                return _seisakuhiList;
            }
            return new ArrayList<FindWorkDetailGenkaVO>();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * フェイズより期間FromToを算出
     * @param phase フェイズ
     * @return 期間From,To
     */
    private List<String> KikanFromPhaseGet(int phase)
    {
        List<String> kikanList = new ArrayList<String>();
        // 期間From
        String kikanFrom = String.valueOf(phase + PHASE_NEN_KEISU) + "0401";
        // 期間To
        String kikanTo = String.valueOf(phase + PHASE_NEN_KEISU + 1) + "0331";

        kikanList.add(kikanFrom);
        kikanList.add(kikanTo);

        return kikanList;
    }

    /**
     * 上期下期を判定
     * @param crDate 年月
     * @return 期間
     */
    private String termGet(String crDate)
    {
        // 年月の月を取得
        int month = Integer.valueOf(crDate.substring(5, 7));

        if ((4 <= month) && (month <= 9)) {
            // 上期
            return FIRST_TERM;
        } else {
            // 下期
            return SECOND_TERM;
        }
    }

    /**
     * 制作費管理NOリストからSQL生成
     * @param phase フェイズ
     * @return 期間From,To
     */
    private String setSQLseqList()
    {
        StringBuffer sql = new StringBuffer();

        sql.append(" ( ");

        for (int i = 0; i < _seisakuhiList.size(); i++) {

            if (i > 0){
                sql.append(" , ");
            }

            sql.append(" '" + _seisakuhiList.get(i).get(Tbj22SeisakuhiSs.SEQUENCENO) + "' ");
        }
        sql.append(" ) ");

        return sql.toString();
    }
}
