package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * 制作費取込DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindCostManagementCaptureDAO extends AbstractRdbDao {

    private FindCostManagementCaptureCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindCostManagementCaptureDAO() {
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
                Tbj22SeisakuhiSs.DCARCD,
                Tbj22SeisakuhiSs.GROUPCD,
                "SUM(" + Tbj22SeisakuhiSs.CLMMONEY  + ") AS " + Tbj22SeisakuhiSs.CLMMONEY
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return Tbj22SeisakuhiSs.TBNAME + ", " + Mbj05Car.TBNAME;
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
        sql.append(" AND ");
        sql.append(Mbj05Car.DISPSTS);
        sql.append(" = '1'");
        sql.append(" AND ");
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
        sql.append(" GROUP BY ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(", ");
        sql.append(Tbj22SeisakuhiSs.GROUPCD);
        sql.append(" ORDER BY ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(", ");
        sql.append(Tbj22SeisakuhiSs.GROUPCD);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindCostManagementCaptureVO> selectVO(FindCostManagementCaptureCondition condition) throws HAMException {

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        if (condition.getPhase() == 0) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        if (condition.getYearMonth() == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        if (condition.getClassDiv() == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new FindCostManagementCaptureVO());
        try {
            _condition = condition;
            return (List<FindCostManagementCaptureVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
