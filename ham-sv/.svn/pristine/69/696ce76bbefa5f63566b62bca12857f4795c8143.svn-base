package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * HC見積一覧(見積案件)取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/6 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateListItemDAO extends AbstractRdbDao {

//    /** 権限(参照のみ) */
//    private String AUTHORITY_REF_ONLY = "1";
//
//    /** 権限(参照・更新) */
//    private String AUTHORITY_REF_REG = "2";

    FindHCEstimateListItemCondition _condition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{COND, ESTESQNO};
    private SelSqlMode _SelSqlMode = SelSqlMode.COND;

    /**
     * デフォルトコンストラクタ
     */
    public FindHCEstimateListItemDAO() {
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
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{
                Tbj05EstimateItem.PHASE,
                Tbj05EstimateItem.CRDATE,
                Tbj05EstimateItem.ESTSEQNO,
                Tbj05EstimateItem.ESTIMATECLASS,
                Tbj05EstimateItem.ESTIMATEDATE,
                Tbj05EstimateItem.COOPKBN,
                Tbj05EstimateItem.ADDRESS,
                Tbj05EstimateItem.ESTIMATENM,
                Tbj05EstimateItem.HCBUMONCD,
                Tbj05EstimateItem.HCUSERNM,
                Tbj05EstimateItem.DLVDATE,
                Tbj05EstimateItem.DISCOUNTRATE,
                Tbj05EstimateItem.BIKO,
                Tbj05EstimateItem.LASTOUTPUTDATE,
                Tbj05EstimateItem.LASTOUTPUTNM,
                Tbj05EstimateItem.OUTPUTFILENM,
                Tbj05EstimateItem.DCARCD,
                Tbj05EstimateItem.DIVCD,
                Tbj05EstimateItem.GROUPCD,
                Tbj05EstimateItem.CRTDATE,
                Tbj05EstimateItem.CRTNM,
                Tbj05EstimateItem.CRTAPL,
                Tbj05EstimateItem.CRTID,
                Tbj05EstimateItem.UPDDATE,
                Tbj05EstimateItem.UPDNM,
                Tbj05EstimateItem.UPDAPL,
                Tbj05EstimateItem.UPDID,
                Mbj05Car.CARNM,
                Mbj17CrDivision.DIVNM,
                "NVL(" + Mbj26BillGroup.GROUPNM + ", '請求グループ未設定') " + Mbj26BillGroup.GROUPNM,
                Mbj12Code.CODENAME,
                Mbj06HcBumon.HCBUMONNM,
                "(" + getEstimateSum() + ") AS " + Tbj06EstimateDetail.MITUMORI,
                getEstimateNo() + " AS ESTIMATENO"
        };
    }

    /**
     * 見積明細の見積金額の合計を取得するSQL文を返す
     *
     * @return String SQL文
     */
    private String getEstimateSum()
    {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT NVL(SUM(");
        sql.append(Tbj06EstimateDetail.MITUMORI);
        sql.append("), 0)");
        sql.append(" FROM ");
        sql.append(Tbj06EstimateDetail.TBNAME);
        sql.append(" WHERE ");
        sql.append(Tbj06EstimateDetail.PHASE);
        sql.append(" = ");
        sql.append(Tbj05EstimateItem.PHASE);
        sql.append(" AND ");
        sql.append(Tbj06EstimateDetail.CRDATE);
        sql.append(" = ");
        sql.append(Tbj05EstimateItem.CRDATE);
        sql.append(" AND ");
        sql.append(Tbj06EstimateDetail.ESTSEQNO);
        sql.append(" = ");
        sql.append(Tbj05EstimateItem.ESTSEQNO);

        return sql.toString();
    }

    /**
     * 見積番号を作成するSQL文を返す
     *
     * @return String SQL文
     */
    public String getEstimateNo()
    {
        StringBuffer sql = new StringBuffer();

        sql.append("TO_CHAR(");
        sql.append(Tbj05EstimateItem.CRDATE);
        sql.append(", 'MM')");
        sql.append(" || '月-'");
        sql.append(" || TRIM(TO_CHAR(");
        sql.append(Tbj05EstimateItem.ESTSEQNO);
        sql.append(", '0000'))");
        sql.append(" || '-'");
        sql.append(" || TO_CHAR(");
        sql.append(Tbj05EstimateItem.COOPKBN);
        sql.append(")");

        return sql.toString();
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        StringBuffer tbl = new StringBuffer();

        tbl.append("(");
        tbl.append(getEstimateItem());
        tbl.append(") EstimateItem");
        tbl.append(", ");
        tbl.append(Mbj05Car.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj17CrDivision.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj26BillGroup.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj06HcBumon.TBNAME);
        tbl.append(", (");
        tbl.append(getCoopKbn());
        tbl.append(") CD");

        return tbl.toString();
    }

    public String getEstimateItem() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT EstimateItem.* ");
        sql.append(" FROM ");
        sql.append(Tbj05EstimateItem.TBNAME);
        sql.append(" EstimateItem ");
        sql.append(" WHERE ");
        sql.append(Tbj05EstimateItem.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.CRDATE);
        sql.append(" = TO_DATE('");
        sql.append(_condition.getYearMonth());
        sql.append("', 'YYYY/MM')");
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.ESTIMATECLASS);
        sql.append(" = '");
        sql.append(_condition.getEstimateClass());
        sql.append("'");

        if (_condition.getEstSeqNo() != null) {
            sql.append(" AND ");
            sql.append(Tbj05EstimateItem.ESTSEQNO);
            sql.append(" = ");
            sql.append(_condition.getEstSeqNo());
        }

//      見積一覧は、車種権限によらず表示する
//        sql.append(" AND ");
//        sql.append(Tbj05EstimateItem.DCARCD);
//        sql.append(" IS NULL ");
//
//        sql.append(" UNION ALL ");
//        sql.append("SELECT EstimateItem.* ");
//        sql.append(" FROM ");
//        sql.append(Tbj05EstimateItem.TBNAME);
//        sql.append(" EstimateItem ");
//        sql.append(", ");
//        sql.append(Mbj11CarSec.TBNAME);
//        sql.append(" WHERE ");
//        sql.append(Tbj05EstimateItem.PHASE);
//        sql.append(" = ");
//        sql.append(_condition.getPhase());
//        sql.append(" AND ");
//        sql.append(Tbj05EstimateItem.CRDATE);
//        sql.append(" = TO_DATE('");
//        sql.append(_condition.getYearMonth());
//        sql.append("', 'YYYY/MM')");
//        sql.append(" AND ");
//        sql.append(Tbj05EstimateItem.ESTIMATECLASS);
//        sql.append(" = '");
//        sql.append(_condition.getEstimateClass());
//        sql.append("'");
//
//        if (_condition.getEstSeqNo() != null) {
//            sql.append(" AND ");
//            sql.append(Tbj05EstimateItem.ESTSEQNO);
//            sql.append(" = ");
//            sql.append(_condition.getEstSeqNo());
//        }
//
//        sql.append(" AND ");
//        sql.append(Mbj11CarSec.SECTYPE);
//        sql.append(" = '1'");
//        sql.append(" AND ");
//        sql.append(Mbj11CarSec.HAMID);
//        sql.append(" = '");
//        sql.append(_condition.getHamId());
//        sql.append("'");
//        sql.append(" AND ");
//        sql.append(Mbj11CarSec.DCARCD);
//        sql.append(" = ");
//        sql.append(Tbj05EstimateItem.DCARCD);
//        sql.append(" AND ");
//        sql.append(Mbj11CarSec.AUTHORITY);
//        sql.append(" IN ('");
//        sql.append(AUTHORITY_REF_ONLY);
//        sql.append("', '");
//        sql.append(AUTHORITY_REF_REG);
//        sql.append("')");

        return sql.toString();
    }

    /**
     * コープ区分の値と名称を取得するSQL文を返す
     *
     * @return SQL文
     */
    public String getCoopKbn() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        sql.append(Mbj12Code.KEYCODE);
        sql.append(", ");
        sql.append(Mbj12Code.CODENAME);
        sql.append(" FROM ");
        sql.append(Mbj12Code.TBNAME);
        sql.append(" WHERE ");
        sql.append(Mbj12Code.CODETYPE);
        sql.append(" = '");
        sql.append(_condition.getCodeType());
        sql.append("'");

        return sql.toString();
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
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        if (_SelSqlMode.equals(SelSqlMode.COND)) {
            sql.append("SELECT ");
            //全項目を取得
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append(getTableColumnNames()[i]);
                if (i < getTableColumnNames().length-1) {
                    sql.append(", ");
                }
            }

            sql.append(" FROM ");
            sql.append(getTableName());

            sql.append(" WHERE ");
            sql.append(Tbj05EstimateItem.DCARCD);
            sql.append(" = ");
            sql.append(Mbj05Car.DCARCD);
            sql.append("(+)");
            sql.append(" AND ");
            sql.append(Tbj05EstimateItem.DIVCD);
            sql.append(" = ");
            sql.append(Mbj17CrDivision.DIVCD);
            sql.append("(+)");
            sql.append(" AND ");
            sql.append(Tbj05EstimateItem.GROUPCD);
            sql.append(" = ");
            sql.append(Mbj26BillGroup.GROUPCD);
            sql.append("(+)");
            sql.append(" AND ");
            sql.append(Tbj05EstimateItem.COOPKBN);
            sql.append(" = ");
            sql.append(Mbj12Code.KEYCODE);
            sql.append("(+)");
            sql.append(" AND ");
            sql.append(Tbj05EstimateItem.HCBUMONCD);
            sql.append(" = ");
            sql.append(Mbj06HcBumon.HCBUMONCD);

            sql.append(" ORDER BY ");
            sql.append(Tbj05EstimateItem.ESTIMATENM);
            sql.append(", ");
            sql.append(Tbj05EstimateItem.ESTSEQNO);
        }
        else {
            sql.append("SELECT ");
            sql.append("NVL(MAX(");
            sql.append(Tbj05EstimateItem.ESTSEQNO);
            sql.append("), 0) + 1 AS ");
            sql.append(Tbj05EstimateItem.ESTSEQNO);

            sql.append(" FROM ");
            sql.append(Tbj05EstimateItem.TBNAME);

            sql.append(" WHERE ");
            sql.append(Tbj05EstimateItem.PHASE);
            sql.append(" = ");
            sql.append(_condition.getPhase());
            sql.append(" AND ");
            sql.append(Tbj05EstimateItem.CRDATE);
            sql.append(" = TO_DATE('");
            sql.append(_condition.getYearMonth());
            sql.append("', 'YYYY/MM')");
        }

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHCEstimateListItemVO> selectVO(FindHCEstimateListItemCondition condition) throws HAMException {
        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindHCEstimateListItemVO());
        try
        {
            _SelSqlMode = SelSqlMode.COND;
            _condition = condition;
            return (List<FindHCEstimateListItemVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 見積案件管理NOを取得します
     * @return 見積案件管理NO
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHCEstimateListItemVO> getEstSeqNo(FindHCEstimateListItemCondition condition) throws HAMException {
        super.setModel(new FindHCEstimateListItemVO());
        try
        {
            _SelSqlMode = SelSqlMode.ESTESQNO;
            _condition = condition;
            return (List<FindHCEstimateListItemVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
