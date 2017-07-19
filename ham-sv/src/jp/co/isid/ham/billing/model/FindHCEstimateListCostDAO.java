package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
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
 * HC見積一覧(制作原価)取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/4 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateListCostDAO extends AbstractRdbDao {

    private FindHCEstimateListCostCondition _condition = null;

    /** 権限(参照のみ) */
    private String AUTHORITY_REF_ONLY = "1";

    /** 権限(参照・更新) */
    private String AUTHORITY_REF_REG = "2";

    /**
     * デフォルトコンストラクタ
     */
    public FindHCEstimateListCostDAO() {
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
                Tbj22SeisakuhiSs.DCARCD
                ,Tbj22SeisakuhiSs.DIVCD
                ,Tbj22SeisakuhiSs.GROUPCD
                ,Tbj22SeisakuhiSs.ESTMONEY
                ,Tbj22SeisakuhiSs.CLMMONEY
                ,Mbj05Car.CARNM
                ,Mbj17CrDivision.DIVNM
                ,"NVL(" + Mbj26BillGroup.GROUPNM + ", '請求グループ未設定') " + Mbj26BillGroup.GROUPNM
        };
    }

    /**
     * インナーテーブル列名を返します
     *
     * @return String[] インナーテーブル列名
     */
    public String[] getInnerTableColumnNames() {
        return new String[]{
                Tbj22SeisakuhiSs.DCARCD
                ,Tbj22SeisakuhiSs.DIVCD
                ,Tbj22SeisakuhiSs.GROUPCD
                ,"SUM(" + Tbj22SeisakuhiSs.ESTMONEY + ") " + Tbj22SeisakuhiSs.ESTMONEY
                ,"SUM(" + Tbj22SeisakuhiSs.CLMMONEY + ") " + Tbj22SeisakuhiSs.CLMMONEY
        };
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
        tbl.append(getInnerTableName());
        tbl.append(") DA, ");
        tbl.append(Mbj05Car.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj17CrDivision.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj26BillGroup.TBNAME);

        return tbl.toString();
    }

    /**
     * インナーテーブルのSQL分を取得する
     *
     * @return String インナーテーブルSQL
     */
    private String getInnerTableName() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        //全項目を取得
        for (int i = 0; i < getInnerTableColumnNames().length; i++) {
            sql.append(getInnerTableColumnNames()[i]);
            if (i < getInnerTableColumnNames().length-1) {
                sql.append(", ");
            }
        }
        sql.append(" FROM ");
        sql.append(Tbj22SeisakuhiSs.TBNAME);
        sql.append(" WHERE ");
        sql.append(Tbj22SeisakuhiSs.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CRDATE);
        sql.append(" = TO_DATE('");
        sql.append(_condition.getYearMonth());
        sql.append("', 'YYYY/MM')");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CLASSDIV);
        sql.append(" = '");
        sql.append(_condition.getClassDiv());
        sql.append("'");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(" IN (");
        sql.append(getValidDCarCd());
        sql.append(")");
        sql.append(" AND ");
        sql.append(" NOT EXISTS (");
        sql.append(getIncludingExtimate());
        sql.append(")");
        sql.append(" GROUP BY ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(", ");
        sql.append(Tbj22SeisakuhiSs.DIVCD);
        sql.append(", ");
        sql.append(Tbj22SeisakuhiSs.GROUPCD);
        sql.append(" ORDER BY ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(", ");
        sql.append(Tbj22SeisakuhiSs.DIVCD);
        sql.append(", ");
        sql.append(Tbj22SeisakuhiSs.GROUPCD);

        return sql.toString();
    }

    /**
     * 有効な電通車種コードを取得する
     *
     * @return 有効な電通車種コード
     */
    private String getValidDCarCd() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        sql.append(Mbj05Car.DCARCD);
        sql.append(" FROM ");
        sql.append(Mbj05Car.TBNAME);
        sql.append(",");
        sql.append(Mbj11CarSec.TBNAME);
        sql.append(" WHERE ");
        sql.append(Mbj05Car.DISPSTS);
        sql.append(" = '1'");
        sql.append(" AND ");
        sql.append(Mbj11CarSec.SECTYPE);
        sql.append(" = '1'");
        sql.append(" AND ");
        sql.append(Mbj11CarSec.HAMID);
        sql.append(" = '");
        sql.append(_condition.getHamId());
        sql.append("'");
        sql.append(" AND ");
        sql.append(Mbj05Car.DCARCD);
        sql.append(" = ");
        sql.append(Mbj11CarSec.DCARCD);
        sql.append(" AND ");
        sql.append(Mbj11CarSec.AUTHORITY);
        sql.append(" IN ('");
        sql.append(AUTHORITY_REF_ONLY);
        sql.append("', '");
        sql.append(AUTHORITY_REF_REG);
        sql.append("')");

        return sql.toString();
    }

    /**
     * 見積もりを含んでいる制作費原価データを取得する
     *
     * @return 見積もりを含んでいる制作費原価データ
     */
    private String getIncludingExtimate()
    {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT *");
        sql.append(" FROM ");
        sql.append(Tbj05EstimateItem.TBNAME);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.TBNAME);
        sql.append(", ");
        sql.append(Tbj07EstimateCreate.TBNAME);
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
        sql.append(Tbj05EstimateItem.DCARCD);
        sql.append(" = ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.DIVCD);
        sql.append(" = ");
        sql.append(Tbj22SeisakuhiSs.DIVCD);
        sql.append(" AND ");
        sql.append("(");
        sql.append("(");
        sql.append(Tbj05EstimateItem.GROUPCD);
        sql.append(" IS NULL");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.GROUPCD);
        sql.append(" IS NULL");
        sql.append(")");
        sql.append(" OR ");
        sql.append("(");
        sql.append(Tbj05EstimateItem.GROUPCD);
        sql.append(" = ");
        sql.append(Tbj22SeisakuhiSs.GROUPCD);
        sql.append(")");
        sql.append(")");
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.ESTSEQNO);
        sql.append(" = ");
        sql.append(Tbj06EstimateDetail.ESTSEQNO);
        sql.append(" AND ");
        sql.append(Tbj06EstimateDetail.ESTDETAILSEQNO);
        sql.append(" = ");
        sql.append(Tbj07EstimateCreate.ESTDETAILSEQNO);
        sql.append(" AND ");
        sql.append(Tbj07EstimateCreate.SEQUENCENO);
        sql.append(" = ");
        sql.append(Tbj22SeisakuhiSs.SEQUENCENO);

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
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(" = ");
        sql.append(Mbj05Car.DCARCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.DIVCD);
        sql.append(" = ");
        sql.append(Mbj17CrDivision.DIVCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.GROUPCD);
        sql.append(" = ");
        sql.append(Mbj26BillGroup.GROUPCD);
        sql.append("(+)");
        sql.append(" ORDER BY ");
        sql.append(Mbj05Car.SORTNO);
        sql.append(", ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(", ");
        sql.append(Tbj22SeisakuhiSs.DIVCD);
        sql.append(", ");
        sql.append(Tbj22SeisakuhiSs.GROUPCD);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHCEstimateListCostVO> selectVO(FindHCEstimateListCostCondition condition) throws HAMException {
      //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindHCEstimateListCostVO());
        try
        {
            _condition = condition;
            return (List<FindHCEstimateListCostVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
