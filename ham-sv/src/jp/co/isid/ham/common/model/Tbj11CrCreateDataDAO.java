package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR制作費管理DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj11CrCreateDataDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj11CrCreateDataCondition _condition = null;
    private List<Tbj11CrCreateDataVO> _conditions = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{LOAD, COND, MAXSEQ, MAXTIME, MAXSORT, LOCK, };
    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /** getExecSQLで発行するSQLのモード() */
    private enum ExecSqlMode{UPD, UPDSORT, };
    private ExecSqlMode _ExecSqlMode = ExecSqlMode.UPD;

    private enum StoreMode {INS, UPD, };
    private StoreMode _StoreMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj11CrCreateDataDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     *
     * @return String[] プライマリキー
     */
    public String[] getPrimryKeyNames() {
        return new String[] {
                Tbj11CrCreateData.DCARCD
                ,Tbj11CrCreateData.PHASE
                ,Tbj11CrCreateData.CRDATE
                ,Tbj11CrCreateData.SEQUENCENO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj11CrCreateData.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        if (StoreMode.INS.equals(_StoreMode)) {
            return new String[] {
                    Tbj11CrCreateData.CRTDATE
                    ,Tbj11CrCreateData.UPDDATE
            };
        } else if (StoreMode.UPD.equals(_StoreMode)) {
            return new String[] {
                    Tbj11CrCreateData.UPDDATE
            };
        } else {
            return new String[] {};
        }
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj11CrCreateData.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj11CrCreateData.DCARCD
                ,Tbj11CrCreateData.PHASE
                ,Tbj11CrCreateData.CRDATE
                ,Tbj11CrCreateData.SEQUENCENO
                ,Tbj11CrCreateData.CLASSDIV
                ,Tbj11CrCreateData.SORTNO
                ,Tbj11CrCreateData.CLASSCD
                ,Tbj11CrCreateData.EXPCD
                ,Tbj11CrCreateData.EXPENSE
                ,Tbj11CrCreateData.DETAIL
                ,Tbj11CrCreateData.KIKANS
                ,Tbj11CrCreateData.KIKANE
                ,Tbj11CrCreateData.CONTRACTDATE
                ,Tbj11CrCreateData.CONTRACTTERM
                ,Tbj11CrCreateData.SEIKYU
                ,Tbj11CrCreateData.TRTHSKGYCD
                ,Tbj11CrCreateData.TRSEQNO
                ,Tbj11CrCreateData.ORDERNO
                ,Tbj11CrCreateData.PAY
                ,Tbj11CrCreateData.HRTHSKGYCD
                ,Tbj11CrCreateData.HRSEQNO
                ,Tbj11CrCreateData.USERNAME
                ,Tbj11CrCreateData.GETMONEY
                ,Tbj11CrCreateData.GETCONF
                ,Tbj11CrCreateData.PAYMONEY
                ,Tbj11CrCreateData.PAYCONF
                ,Tbj11CrCreateData.ESTMONEY
                ,Tbj11CrCreateData.CLMMONEY
                ,Tbj11CrCreateData.DELIVERDAY
                ,Tbj11CrCreateData.SETMONTH
                ,Tbj11CrCreateData.DIVCD
                ,Tbj11CrCreateData.GROUPCD
                ,Tbj11CrCreateData.STKYKNO
                ,Tbj11CrCreateData.STTNTID
                ,Tbj11CrCreateData.STTNTNM
                ,Tbj11CrCreateData.EGTYKFLG
                ,Tbj11CrCreateData.INPUTTNTCD
                ,Tbj11CrCreateData.CPTNTNM
                ,Tbj11CrCreateData.NOTE
                ,Tbj11CrCreateData.TCKEY
                ,Tbj11CrCreateData.TRSUBNO
                ,Tbj11CrCreateData.HRSUBNO
                ,Tbj11CrCreateData.RSTATUS
                ,Tbj11CrCreateData.STPKBN
                ,Tbj11CrCreateData.DCARCDFLG
                ,Tbj11CrCreateData.CLASSCDFLG
                ,Tbj11CrCreateData.EXPCDFLG
                ,Tbj11CrCreateData.EXPENSEFLG
                ,Tbj11CrCreateData.DETAILFLG
                ,Tbj11CrCreateData.KIKANSFLG
                ,Tbj11CrCreateData.KIKANEFLG
                ,Tbj11CrCreateData.CONTRACTDATEFLG
                ,Tbj11CrCreateData.CONTRACTTERMFLG
                ,Tbj11CrCreateData.SEIKYUFLG
                ,Tbj11CrCreateData.ORDERNOFLG
                ,Tbj11CrCreateData.PAYFLG
                ,Tbj11CrCreateData.USERNAMEFLG
                ,Tbj11CrCreateData.GETMONEYFLG
                ,Tbj11CrCreateData.GETCONFIRMFLG
                ,Tbj11CrCreateData.PAYMONEYFLG
                ,Tbj11CrCreateData.PAYCONFIRMFLG
                ,Tbj11CrCreateData.ESTMONEYFLG
                ,Tbj11CrCreateData.CLMMONEYFLG
                ,Tbj11CrCreateData.DELIVERDAYFLG
                ,Tbj11CrCreateData.SETMONTHFLG
                ,Tbj11CrCreateData.DIVISIONFLG
                ,Tbj11CrCreateData.GROUPCDFLG
                ,Tbj11CrCreateData.STKYKNOFLG
                ,Tbj11CrCreateData.STTNTNMFLG
                ,Tbj11CrCreateData.EGTYKFLGFLG
                ,Tbj11CrCreateData.INPUTTNTCDFLG
                ,Tbj11CrCreateData.CPTNTNMFLG
                ,Tbj11CrCreateData.NOTEFLG
                ,Tbj11CrCreateData.DCARCDCONFFLG
                ,Tbj11CrCreateData.DCARCDCONFSIKCD
                ,Tbj11CrCreateData.DCARCDCONFHAMID
                ,Tbj11CrCreateData.CLASSCDCONFFLG
                ,Tbj11CrCreateData.CLASSCDCONFSIKCD
                ,Tbj11CrCreateData.CLASSCDCONFHAMID
                ,Tbj11CrCreateData.EXPCDCONFFLG
                ,Tbj11CrCreateData.EXPCDCONFSIKCD
                ,Tbj11CrCreateData.EXPCDCONFHAMID
                ,Tbj11CrCreateData.EXPENSECONFFLG
                ,Tbj11CrCreateData.EXPENSECONFSIKCD
                ,Tbj11CrCreateData.EXPENSECONFHAMID
                ,Tbj11CrCreateData.DETAILCONFFLG
                ,Tbj11CrCreateData.DETAILCONFSIKCD
                ,Tbj11CrCreateData.DETAILCONFHAMID
                ,Tbj11CrCreateData.KIKANSCONFFLG
                ,Tbj11CrCreateData.KIKANSCONFSIKCD
                ,Tbj11CrCreateData.KIKANSCONFHAMID
                ,Tbj11CrCreateData.KIKANECONFFLG
                ,Tbj11CrCreateData.KIKANECONFSIKCD
                ,Tbj11CrCreateData.KIKANECONFHAMID
                ,Tbj11CrCreateData.CONTRACTDATECONFFLG
                ,Tbj11CrCreateData.CONTRACTDATECONFSIKCD
                ,Tbj11CrCreateData.CONTRACTDATECONFHAMID
                ,Tbj11CrCreateData.CONTRACTTERMCONFFLG
                ,Tbj11CrCreateData.CONTRACTTERMCONFSIKCD
                ,Tbj11CrCreateData.CONTRACTTERMCONFHAMID
                ,Tbj11CrCreateData.SEIKYUCONFFLG
                ,Tbj11CrCreateData.SEIKYUCONFSIKCD
                ,Tbj11CrCreateData.SEIKYUCONFHAMID
                ,Tbj11CrCreateData.ORDERNOCONFFLG
                ,Tbj11CrCreateData.ORDERNOCONFSIKCD
                ,Tbj11CrCreateData.ORDERNOCONFHAMID
                ,Tbj11CrCreateData.PAYCONFFLG
                ,Tbj11CrCreateData.PAYCONFSIKCD
                ,Tbj11CrCreateData.PAYCONFHAMID
                ,Tbj11CrCreateData.USERNAMECONFFLG
                ,Tbj11CrCreateData.USERNAMECONFSIKCD
                ,Tbj11CrCreateData.USERNAMECONFHAMID
                ,Tbj11CrCreateData.GETMONEYCONFFLG
                ,Tbj11CrCreateData.GETMONEYCONFSIKCD
                ,Tbj11CrCreateData.GETMONEYCONFHAMID
                ,Tbj11CrCreateData.GETCONFCONFFLG
                ,Tbj11CrCreateData.GETCONFCONFSIKCD
                ,Tbj11CrCreateData.GETCONFCONFHAMID
                ,Tbj11CrCreateData.PAYMONEYCONFFLG
                ,Tbj11CrCreateData.PAYMONEYCONFSIKCD
                ,Tbj11CrCreateData.PAYMONEYCONFHAMID
                ,Tbj11CrCreateData.PAYCONFCONFFLG
                ,Tbj11CrCreateData.PAYCONFCONFSIKCD
                ,Tbj11CrCreateData.PAYCONFCONFHAMID
                ,Tbj11CrCreateData.ESTMONEYCONFFLG
                ,Tbj11CrCreateData.ESTMONEYCONFSIKCD
                ,Tbj11CrCreateData.ESTMONEYCONFHAMID
                ,Tbj11CrCreateData.CLMMONEYCONFFLG
                ,Tbj11CrCreateData.CLMMONEYCONFSIKCD
                ,Tbj11CrCreateData.CLMMONEYCONFHAMID
                ,Tbj11CrCreateData.DELIVERDAYCONFFLG
                ,Tbj11CrCreateData.DELIVERDAYCONFSIKCD
                ,Tbj11CrCreateData.DELIVERDAYCONFHAMID
                ,Tbj11CrCreateData.SETMONTHCONFFLG
                ,Tbj11CrCreateData.SETMONTHCONFSIKCD
                ,Tbj11CrCreateData.SETMONTHCONFHAMID
                ,Tbj11CrCreateData.DIVISIONCONFFLG
                ,Tbj11CrCreateData.DIVISIONCONFSIKCD
                ,Tbj11CrCreateData.DIVISIONCONFHAMID
                ,Tbj11CrCreateData.GROUPCDCONFFLG
                ,Tbj11CrCreateData.GROUPCDCONFSIKCD
                ,Tbj11CrCreateData.GROUPCDCONFHAMID
                ,Tbj11CrCreateData.STKYKNOCONFFLG
                ,Tbj11CrCreateData.STKYKNOCONFSIKCD
                ,Tbj11CrCreateData.STKYKNOCONFHAMID
                ,Tbj11CrCreateData.STTNTNMCONFFLG
                ,Tbj11CrCreateData.STTNTNMCONFSIKCD
                ,Tbj11CrCreateData.STTNTNMCONFHAMID
                ,Tbj11CrCreateData.EGTYKCONFFLG
                ,Tbj11CrCreateData.EGTYKCONFSIKCD
                ,Tbj11CrCreateData.EGTYKCONFHAMID
                ,Tbj11CrCreateData.INPUTTNTCDCONFFLG
                ,Tbj11CrCreateData.INPUTTNTCDCONFSIKCD
                ,Tbj11CrCreateData.INPUTTNTCDCONFHAMID
                ,Tbj11CrCreateData.CPTNTNMCONFFLG
                ,Tbj11CrCreateData.CPTNTNMCONFSIKCD
                ,Tbj11CrCreateData.CPTNTNMCONFHAMID
                ,Tbj11CrCreateData.NOTECONFFLG
                ,Tbj11CrCreateData.NOTECONFSIKCD
                ,Tbj11CrCreateData.NOTECONFHAMID
                ,Tbj11CrCreateData.CRTDATE
                ,Tbj11CrCreateData.CRTNM
                ,Tbj11CrCreateData.CRTAPL
                ,Tbj11CrCreateData.CRTID
                ,Tbj11CrCreateData.UPDDATE
                ,Tbj11CrCreateData.UPDNM
                ,Tbj11CrCreateData.UPDAPL
                ,Tbj11CrCreateData.UPDID
        };
    }



    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        if (_SelSqlMode.equals(SelSqlMode.LOAD)) {

            //*******************************************
            //Load()で使用されるSELECT + FROM句のSQL
            //*******************************************
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.COND)) {

            //*******************************************
            //selectVOで使用されるSQL
            //*******************************************
            //SELECT + FROM句
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");
            //WHERE句
            sql.append(generateWhereByCond(getModel()));
            //OrderBy句
            sql.append(" ORDER BY ");
            sql.append(" " + Tbj11CrCreateData.SORTNO + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.MAXSEQ)) {

            //*******************************************
            //findMaxSeqNoで使用されるSQL
            //*******************************************
            //SELECT + FROM句
            sql.append(" SELECT ");
            sql.append("     NVL(MAX(" + Tbj11CrCreateData.SEQUENCENO  + "), 0) AS " + Tbj11CrCreateData.SEQUENCENO + " ");
            sql.append(" FROM ");
            sql.append(" " + Tbj11CrCreateData.TBNAME + " ");
            //WHERE句
            sql.append(generateWhereByCond(convertCondToVo(_condition)));
//            sql.append(" WHERE ");
//            sql.append("     " + Tbj11CrCreateData.DCARCD + " = " + getDBModelInterface().ConvertToDBString(_condition.getDcarcd()) + " ");
//            sql.append(" AND " + Tbj11CrCreateData.PHASE + " = " + getDBModelInterface().ConvertToDBString(_condition.getPhase()) + " ");
//            sql.append(" AND " + Tbj11CrCreateData.CRDATE + " = " + getDBModelInterface().ConvertToDBString(_condition.getCrdate()) + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.MAXSORT)) {

            //*******************************************
            //findMaxSortNoで使用されるSQL
            //*******************************************
            //SELECT + FROM句
            sql.append(" SELECT ");
            sql.append("     NVL(MAX(" + Tbj11CrCreateData.SORTNO  + "), 0) AS " + Tbj11CrCreateData.SORTNO + " ");
            sql.append(" FROM ");
            sql.append(" " + Tbj11CrCreateData.TBNAME + " ");
            //WHERE句
            sql.append(generateWhereByCond(convertCondToVo(_condition)));
//            sql.append(" WHERE ");
//            sql.append("     " + Tbj11CrCreateData.DCARCD + " = " + getDBModelInterface().ConvertToDBString(_condition.getDcarcd()) + " ");
//            sql.append(" AND " + Tbj11CrCreateData.PHASE + " = " + getDBModelInterface().ConvertToDBString(_condition.getPhase()) + " ");
//            sql.append(" AND " + Tbj11CrCreateData.CRDATE + " = " + getDBModelInterface().ConvertToDBString(_condition.getCrdate()) + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.MAXTIME)) {

            // *******************************************
            // findMaxTimeStampで使用されるSQL
            // *******************************************
            sql.append(" SELECT ");
            sql.append("     NVL(MAX(" + getTimeStampKeyName() + "), SYSDATE) AS " + getTimeStampKeyName() + " ");
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");
            //WHERE句
            sql.append(generateWhereByCond(getModel()));

        } else if (_SelSqlMode.equals(SelSqlMode.LOCK)) {

            // *******************************************
            // 排他用SQL
            // *******************************************
            sql.append(" SELECT ");
            sql.append(" " + getTimeStampKeyName() + " ");
            for (int i = 0; i < getPrimryKeyNames().length; i++) {
                sql.append(" ," + getPrimryKeyNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");
            sql.append(" WHERE ");
            for (int i = 0; i < _conditions.size(); i++) {
                AbstractModel cond = _conditions.get(i);
                sql.append((i != 0 ? " OR " : " "));
                sql.append(" ( ");
                for (int j = 0; j < getPrimryKeyNames().length; j++) {
                    sql.append((j != 0 ? " AND " : " "));
                    sql.append("" + getPrimryKeyNames()[j] +" ");
                    sql.append(" = ");
                    sql.append(ConvertToDBString(cond.get(getPrimryKeyNames()[j])));
                }
                sql.append(" ) ");
            }
            sql.append(" FOR UPDATE NOWAIT ");
        }

        return sql.toString();
    };

    /**
     * 値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo) {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            Object value = vo.get(getTableColumnNames()[i]);
            if (value != null) {
                if (sql.length() == 0) {
                    sql.append(" WHERE ");
                } else {
                    sql.append(" AND ");
                }
                sql.append(getTableColumnNames()[i] + " = " + ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /**
     * 値の設定有無からUPDATEのSET句を生成する
     * @param vo
     * @return
     */
    private String generateSetByCond(AbstractModel vo) {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            String columnName = getTableColumnNames()[i];
            Object value = vo.get(columnName);
            if (getTimeStampKeyName().equals(columnName)) {
                //システム日付で更新する項目の場合は値の有無に関係なくSYSDATEで更新
                if (sql.length() == 0) {
                    sql.append(" SET ");
                } else {
                    sql.append("    ,");
                }
                sql.append(columnName + " = " + getDBModelInterface().getSystemDateString());
            } else {
                if (value != null) {
                //if (vo.getUpdateMember().containsKey(columnName)) {
                    if (sql.length() == 0) {
                        sql.append(" SET ");
                    } else {
                        sql.append("    ,");
                    }
                    if (value != null) {
                        sql.append(columnName + " = " + ConvertToDBString(value));
                    }
                }
            }
        }

        return sql.toString();
    }

    /**
     * CondtionからVOに変換する
     * @param cond
     * @return
     */
    private Tbj11CrCreateDataVO convertCondToVo(Tbj11CrCreateDataCondition cond) {
        Tbj11CrCreateDataVO vo = new Tbj11CrCreateDataVO();

        vo.setDCARCD(cond.getDcarcd());                                                 //電通車種コード
        vo.setPHASE(cond.getPhase());                                                   //フェイズ
        vo.setCRDATE(cond.getCrdate());                                                 //年月
        vo.setSEQUENCENO(cond.getSequenceno());                                         //制作費管理NO
        vo.setCLASSDIV(cond.getClassdiv());                                             //種別判断フラグ
        vo.setSORTNO(cond.getSortno());                                                 //ソート順
        vo.setCLASSCD(cond.getClasscd());                                               //予算分類コード
        vo.setEXPCD(cond.getExpcd());                                                   //予算表費目コード
        vo.setEXPENSE(cond.getExpense());                                               //費目
        vo.setDETAIL(cond.getDetail());                                                 //詳細
        vo.setKIKANS(cond.getKikans());                                                 //期間開始
        vo.setKIKANE(cond.getKikane());                                                 //期間終了
        vo.setCONTRACTDATE(cond.getContractdate());                                     //契約開始年月日
        vo.setCONTRACTTERM(cond.getContractterm());                                     //契約期間(ヶ月)
        vo.setSEIKYU(cond.getSeikyu());                                                 //請求先
        vo.setORDERNO(cond.getOrderno());                                               //受注NO
        vo.setPAY(cond.getPay());                                                       //支払先
        vo.setUSERNAME(cond.getUsername());                                             //担当者
        vo.setGETMONEY(cond.getGetmoney());                                             //取り金額
        vo.setGETCONF(cond.getGetconf());                                               //取り金額確認
        vo.setPAYMONEY(cond.getPaymoney());                                             //払い金額
        vo.setPAYCONF(cond.getPayconf());                                               //払い金額確認
        vo.setESTMONEY(cond.getEstmoney());                                             //見積金額
        vo.setCLMMONEY(cond.getClmmoney());                                             //請求金額
        vo.setDELIVERDAY(cond.getDeliverday());                                         //支払先納品日
        vo.setSETMONTH(cond.getSetmonth());                                             //設定月
        vo.setDIVCD(cond.getDivcd());                                                   //区分コード
        vo.setGROUPCD(cond.getGroupcd());                                               //グループコード
        vo.setSTKYKNO(cond.getStkykno());                                               //設定局ナンバー
        vo.setEGTYKFLG(cond.getEgtykflg());                                             //営直チェック
        vo.setINPUTTNTCD(cond.getInputtntcd());                                         //入力担当コード
        vo.setCPTNTNM(cond.getCptntnm());                                               //CP担当者名
        vo.setNOTE(cond.getNote());                                                     //備考
        vo.setDCARCDFLG(cond.getDcarcdflg());                                           //電通車種コードフラグ
        vo.setCLASSCDFLG(cond.getClasscdflg());                                         //予算分類フラグ
        vo.setEXPCDFLG(cond.getExpcdflg());                                             //予算表費目フラグ
        vo.setEXPENSEFLG(cond.getExpenseflg());                                         //費目フラグ
        vo.setDETAILFLG(cond.getDetailflg());                                           //詳細フラグ
        vo.setKIKANSFLG(cond.getKikansflg());                                           //期間開始フラグ
        vo.setKIKANEFLG(cond.getKikaneflg());                                           //期間終了フラグ
        vo.setCONTRACTDATEFLG(cond.getContractdateflg());                               //契約開始年月日フラグ
        vo.setCONTRACTTERMFLG(cond.getContracttermflg());                               //契約期間(ヶ月)フラグ
        vo.setSEIKYUFLG(cond.getSeikyuflg());                                           //請求先フラグ
        vo.setORDERNOFLG(cond.getOrdernoflg());                                         //受注NOフラグ
        vo.setPAYFLG(cond.getPayflg());                                                 //支払先フラグ
        vo.setUSERNAMEFLG(cond.getUsernameflg());                                       //担当者フラグ
        vo.setGETMONEYFLG(cond.getGetmoneyflg());                                       //取り金額フラグ
        vo.setGETCONFIRMFLG(cond.getGetconfirmflg());                                   //取り金額確認フラグ
        vo.setPAYMONEYFLG(cond.getPaymoneyflg());                                       //払い金額フラグ
        vo.setPAYCONFIRMFLG(cond.getPayconfirmflg());                                   //払い金額確認フラグ
        vo.setESTMONEYFLG(cond.getEstmoneyflg());                                       //見積金額フラグ
        vo.setCLMMONEYFLG(cond.getClmmoneyflg());                                       //請求金額フラグ
        vo.setDELIVERDAYFLG(cond.getDeliverdayflg());                                   //支払先納品日フラグ
        vo.setSETMONTHFLG(cond.getSetmonthflg());                                       //設定月フラグ
        vo.setDIVISIONFLG(cond.getDivisionflg());                                       //区分フラグ
        vo.setGROUPCDFLG(cond.getGroupcdflg());                                         //グループコードフラグ
        vo.setSTKYKNOFLG(cond.getStkyknoflg());                                         //設定局コードフラグ
        vo.setEGTYKFLGFLG(cond.getEgtykflgflg());                                       //営直チェックフラグ
        vo.setINPUTTNTCDFLG(cond.getInputtntcdflg());                                   //入力担当コードフラグ
        vo.setCPTNTNMFLG(cond.getCptntnmflg());                                         //CP担当者フラグ
        vo.setNOTEFLG(cond.getNoteflg());                                               //備考フラグ
        vo.setDCARCDCONFFLG(cond.getDcarcdconfflg());                                   //電通車種コード確認フラグ
        vo.setDCARCDCONFSIKCD(cond.getDcarcdconfsikcd());                               //電通車種コード確認組織コード
        vo.setDCARCDCONFHAMID(cond.getDcarcdconfhamid());                               //電通車種コード確認担当者コード
        vo.setCLASSCDCONFFLG(cond.getClasscdconfflg());                                 //予算表分類確認フラグ
        vo.setCLASSCDCONFSIKCD(cond.getClasscdconfsikcd());                             //予算表分類確認組織コード
        vo.setCLASSCDCONFHAMID(cond.getClasscdconfhamid());                             //予算表分類確認担当者コード
        vo.setEXPCDCONFFLG(cond.getExpcdconfflg());                                     //予算表費目確認フラグ
        vo.setEXPCDCONFSIKCD(cond.getExpcdconfsikcd());                                 //予算表費目確認組織コード
        vo.setEXPCDCONFHAMID(cond.getExpcdconfhamid());                                 //予算表費目確認担当者コード
        vo.setEXPENSECONFFLG(cond.getExpenseconfflg());                                 //費目確認フラグ
        vo.setEXPENSECONFSIKCD(cond.getExpenseconfsikcd());                             //費目確認組織コード
        vo.setEXPENSECONFHAMID(cond.getExpenseconfhamid());                             //費目確認担当者コード
        vo.setDETAILCONFFLG(cond.getDetailconfflg());                                   //詳細確認フラグ
        vo.setDETAILCONFSIKCD(cond.getDetailconfsikcd());                               //詳細確認組織コード
        vo.setDETAILCONFHAMID(cond.getDetailconfhamid());                               //詳細確認担当者コード
        vo.setKIKANSCONFFLG(cond.getKikansconfflg());                                   //期間開始確認フラグ
        vo.setKIKANSCONFSIKCD(cond.getKikansconfsikcd());                               //期間開始確認組織コード
        vo.setKIKANSCONFHAMID(cond.getKikansconfhamid());                               //期間開始確認担当者コード
        vo.setKIKANECONFFLG(cond.getKikaneconfflg());                                   //期間終了確認フラグ
        vo.setKIKANECONFSIKCD(cond.getKikaneconfsikcd());                               //期間終了確認組織コード
        vo.setKIKANECONFHAMID(cond.getKikaneconfhamid());                               //期間終了確認担当者コード
        vo.setCONTRACTDATECONFFLG(cond.getContractdateconfflg());                       //契約開始年月日確認フラグ
        vo.setCONTRACTDATECONFSIKCD(cond.getContractdateconfsikcd());                   //契約開始年月日確認組織コード
        vo.setCONTRACTDATECONFHAMID(cond.getContractdateconfhamid());                   //契約開始年月日確認担当者コード
        vo.setCONTRACTTERMCONFFLG(cond.getContracttermconfflg());                       //契約期間(ヶ月)確認フラグ
        vo.setCONTRACTTERMCONFSIKCD(cond.getContracttermconfsikcd());                   //契約期間(ヶ月)確認組織コード
        vo.setCONTRACTTERMCONFHAMID(cond.getContracttermconfhamid());                   //契約期間(ヶ月)確認担当者コード
        vo.setSEIKYUCONFFLG(cond.getSeikyuconfflg());                                   //請求先確認フラグ
        vo.setSEIKYUCONFSIKCD(cond.getSeikyuconfsikcd());                               //請求先確認組織コード
        vo.setSEIKYUCONFHAMID(cond.getSeikyuconfhamid());                               //請求先確認担当者コード
        vo.setORDERNOCONFFLG(cond.getOrdernoconfflg());                                 //受注NO確認フラグ
        vo.setORDERNOCONFSIKCD(cond.getOrdernoconfsikcd());                             //受注NO確認組織コード
        vo.setORDERNOCONFHAMID(cond.getOrdernoconfhamid());                             //受注NO確認担当者コード
        vo.setPAYCONFFLG(cond.getPayconfflg());                                         //支払先確認フラグ
        vo.setPAYCONFSIKCD(cond.getPayconfsikcd());                                     //支払先確認組織コード
        vo.setPAYCONFHAMID(cond.getPayconfhamid());                                     //支払先確認担当者コード
        vo.setUSERNAMECONFFLG(cond.getUsernameconfflg());                               //担当者確認フラグ
        vo.setUSERNAMECONFSIKCD(cond.getUsernameconfsikcd());                           //担当者確認組織コード
        vo.setUSERNAMECONFHAMID(cond.getUsernameconfhamid());                           //担当者確認担当者コード
        vo.setGETMONEYCONFFLG(cond.getGetmoneyconfflg());                               //取り金額確認フラグ
        vo.setGETMONEYCONFSIKCD(cond.getGetmoneyconfsikcd());                           //取り金額確認組織コード
        vo.setGETMONEYCONFHAMID(cond.getGetmoneyconfhamid());                           //取り金額確認担当者コード
        vo.setGETCONFCONFFLG(cond.getGetconfconfflg());                                 //取り金額確認確認フラグ
        vo.setGETCONFCONFSIKCD(cond.getGetconfconfsikcd());                             //取り金額確認確認組織コード
        vo.setGETCONFCONFHAMID(cond.getGetconfconfhamid());                             //取り金額確認確認担当者コード
        vo.setPAYMONEYCONFFLG(cond.getPaymoneyconfflg());                               //払い金額確認フラグ
        vo.setPAYMONEYCONFSIKCD(cond.getPaymoneyconfsikcd());                           //払い金額確認組織コード
        vo.setPAYMONEYCONFHAMID(cond.getPaymoneyconfhamid());                           //払い金額確認担当者コード
        vo.setPAYCONFCONFFLG(cond.getPayconfconfflg());                                 //払い金額確認確認フラグ
        vo.setPAYCONFCONFSIKCD(cond.getPayconfconfsikcd());                             //払い金額確認確認組織コード
        vo.setPAYCONFCONFHAMID(cond.getPayconfconfhamid());                             //払い金額確認確認担当者コード
        vo.setESTMONEYCONFFLG(cond.getEstmoneyconfflg());                               //見積金額確認フラグ
        vo.setESTMONEYCONFSIKCD(cond.getEstmoneyconfsikcd());                           //見積金額確認組織コード
        vo.setESTMONEYCONFHAMID(cond.getEstmoneyconfhamid());                           //見積金額確認担当者コード
        vo.setCLMMONEYCONFFLG(cond.getClmmoneyconfflg());                               //請求金額確認フラグ
        vo.setCLMMONEYCONFSIKCD(cond.getClmmoneyconfsikcd());                           //請求金額確認組織コード
        vo.setCLMMONEYCONFHAMID(cond.getClmmoneyconfhamid());                           //請求金額確認担当者コード
        vo.setDELIVERDAYCONFFLG(cond.getDeliverdayconfflg());                           //支払先納品日確認フラグ
        vo.setDELIVERDAYCONFSIKCD(cond.getDeliverdayconfsikcd());                       //支払先納品日確認組織コード
        vo.setDELIVERDAYCONFHAMID(cond.getDeliverdayconfhamid());                       //支払先納品日確認担当者コード
        vo.setSETMONTHCONFFLG(cond.getSetmonthconfflg());                               //設定月確認フラグ
        vo.setSETMONTHCONFSIKCD(cond.getSetmonthconfsikcd());                           //設定月確認組織コード
        vo.setSETMONTHCONFHAMID(cond.getSetmonthconfhamid());                           //設定月確認担当者コード
        vo.setDIVISIONCONFFLG(cond.getDivisionconfflg());                               //区分コード確認フラグ
        vo.setDIVISIONCONFSIKCD(cond.getDivisionconfsikcd());                           //区分コード確認組織コード
        vo.setDIVISIONCONFHAMID(cond.getDivisionconfhamid());                           //区分コード確認担当者コード
        vo.setGROUPCDCONFFLG(cond.getGroupcdconfflg());                                 //グループコード確認フラグ
        vo.setGROUPCDCONFSIKCD(cond.getGroupcdconfsikcd());                             //グループコード確認組織コード
        vo.setGROUPCDCONFHAMID(cond.getGroupcdconfhamid());                             //グループコード確認担当者コード
        vo.setSTKYKNOCONFFLG(cond.getStkyknoconfflg());                                 //設定局ナンバー確認フラグ
        vo.setSTKYKNOCONFSIKCD(cond.getStkyknoconfsikcd());                             //設定局ナンバー確認組織コード
        vo.setSTKYKNOCONFHAMID(cond.getStkyknoconfhamid());                             //設定局ナンバー確認担当者コード
        vo.setEGTYKCONFFLG(cond.getEgtykconfflg());                                     //営直チェック確認フラグ
        vo.setEGTYKCONFSIKCD(cond.getEgtykconfsikcd());                                 //営直チェック確認組織コード
        vo.setEGTYKCONFHAMID(cond.getEgtykconfhamid());                                 //営直チェック確認担当者コード
        vo.setINPUTTNTCDCONFFLG(cond.getInputtntcdconfflg());                           //入力担当コード確認フラグ
        vo.setINPUTTNTCDCONFSIKCD(cond.getInputtntcdconfsikcd());                       //入力担当コード確認組織コード
        vo.setINPUTTNTCDCONFHAMID(cond.getInputtntcdconfhamid());                       //入力担当コード確認担当者コード
        vo.setCPTNTNMCONFFLG(cond.getCptntnmconfflg());                                 //CP担当者確認フラグ
        vo.setCPTNTNMCONFSIKCD(cond.getCptntnmconfsikcd());                             //CP担当者確認組織コード
        vo.setCPTNTNMCONFHAMID(cond.getCptntnmconfhamid());                             //CP担当者確認担当者コード
        vo.setNOTECONFFLG(cond.getNoteconfflg());                                       //備考確認フラグ
        vo.setNOTECONFSIKCD(cond.getNoteconfsikcd());                                   //備考確認組織コード
        vo.setNOTECONFHAMID(cond.getNoteconfhamid());                                   //備考確認担当者コード
        vo.setCRTDATE(cond.getCrtdate());                                               //データ作成日時
        vo.setCRTNM(cond.getCrtnm());                                                   //データ作成者
        vo.setUPDDATE(cond.getUpddate());                                               //データ更新日時
        vo.setUPDNM(cond.getUpdnm());                                                   //データ更新者
        vo.setUPDAPL(cond.getUpdapl());                                                 //更新プログラム
        vo.setUPDID(cond.getUpdid());                                                   //更新担当者ID


        return vo;
    }


    /**
     * SEQUENCENOの現在の最大値を取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj11CrCreateDataVO> findMaxSeqNo(Tbj11CrCreateDataCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj11CrCreateDataVO());
        try {
            _SelSqlMode = SelSqlMode.MAXSEQ;
            _condition = cond;
            return (List<Tbj11CrCreateDataVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * SORTNOの現在の最大値を取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj11CrCreateDataVO> findMaxSortNo(Tbj11CrCreateDataCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj11CrCreateDataVO());
        try {
            _SelSqlMode = SelSqlMode.MAXSORT;
            _condition = cond;
            return (List<Tbj11CrCreateDataVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * TIMESTAMP項目の現在の最大値を取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj11CrCreateDataVO> findMaxTimeStamp(Tbj11CrCreateDataCondition cond) throws HAMException {
        // パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(convertCondToVo(cond));
        try {
            _SelSqlMode = SelSqlMode.MAXTIME;
            _condition = cond;
            return (List<Tbj11CrCreateDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * PKを条件にして検索を行います(複数指定可)
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj11CrCreateDataVO> selectByPkWithLock(List<Tbj11CrCreateDataVO> cond) throws HAMException {
        // パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj11CrCreateDataVO());
        try {
            _SelSqlMode = SelSqlMode.LOCK;
            _conditions = cond;
            return (List<Tbj11CrCreateDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    //public List<Tbj11CrCreateDataVO> selectVO(Tbj11CrCreateDataCondition cond) throws HAMException {
    public List<Tbj11CrCreateDataVO> selectVO(Tbj11CrCreateDataVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(vo);
        try {
            _SelSqlMode = SelSqlMode.COND;
            return (List<Tbj11CrCreateDataVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * PK検索
     * @param cond
     * @return
     * @throws HAMException
     */
    public Tbj11CrCreateDataVO loadVO(Tbj11CrCreateDataVO cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            return (Tbj11CrCreateDataVO)super.load();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    //更新系▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼

    /**
     * 登録
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean insertVO(Tbj11CrCreateDataVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            _StoreMode = StoreMode.INS;
            return super.insert();
        } catch (ConcurrentUpdateException e) {
            //処理件数が0件の場合.
            return false;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * PK更新
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean updateVO(Tbj11CrCreateDataVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            _StoreMode = StoreMode.UPD;
            return super.update();
        } catch (ConcurrentUpdateException e) {
            //処理件数が0件の場合.
            return false;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * PK削除
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean deleteVO(Tbj11CrCreateDataVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);
        try {
            return super.remove();
        } catch (ConcurrentUpdateException e) {
            //処理件数が0件の場合.
            return false;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    @Override
    public String getExecString() {
        String sql = "";

        if (_ExecSqlMode.equals(ExecSqlMode.UPD)) {
            sql = getExecStringForUPD();
        } else {
            sql = getExecStringForUPDSORT();
        }

        return sql.toString();
    }

    /**
     * CR制作費管理更新SQLを取得する
     * @return
     */
    private String getExecStringForUPD() {
        StringBuffer sql = new StringBuffer();

        sql.append(" UPDATE ");
        sql.append("     " + getTableName() + " ");
        //SET句---------------------------------------------------------------------------------------------------------
        sql.append(generateSetByCond(getModel()));
        //WHERE句-------------------------------------------------------------------------------------------------------
        sql.append(generateWhereByCond(convertCondToVo(_condition)));

        return sql.toString();
    }

    /**
     * CR制作費管理.ソートNo更新SQLを取得する
     * @return
     */
    private String getExecStringForUPDSORT() {
        StringBuffer sql = new StringBuffer();

        Tbj11CrCreateDataVO vo = (Tbj11CrCreateDataVO) getModel();

        sql.append(" UPDATE ");
        sql.append("     " + Tbj11CrCreateData.TBNAME);
        sql.append(" SET ");
        sql.append("     " + Tbj11CrCreateData.SORTNO + " = " + ConvertToDBString(vo.getSORTNO()));
        sql.append(" WHERE ");
        sql.append("     " + Tbj11CrCreateData.DCARCD + " = " + ConvertToDBString(vo.getDCARCD()));
        sql.append(" AND " + Tbj11CrCreateData.PHASE + " = " + ConvertToDBString(vo.getPHASE()));
        sql.append(" AND " + Tbj11CrCreateData.CRDATE + " = " + ConvertToDBString(vo.getCRDATE()));
        sql.append(" AND " + Tbj11CrCreateData.SEQUENCENO + " = " + ConvertToDBString(vo.getSEQUENCENO()));

        return sql.toString();
    }

    /**
     * Conditionで指定した条件、VOの内容で更新する
     * @param vo
     * @param cond
     * @throws HAMException
     */
    public void updateVOByCond(Tbj11CrCreateDataVO vo, Tbj11CrCreateDataCondition cond) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);
        _condition = cond;
        try {
            _StoreMode = StoreMode.UPD;
            _ExecSqlMode = ExecSqlMode.UPD;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * ソートNoを更新する
     * @param vo
     * @throws HAMException
     */
    public void updateSortNo(Tbj11CrCreateDataVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            _StoreMode = StoreMode.UPD;
            _ExecSqlMode = ExecSqlMode.UPDSORT;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    private String ConvertToDBString(Object obj) {
        return super.getDBModelInterface().ConvertToDBString(obj);
    }
}
