package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj21Seisakuhi;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * 制作費車種取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindCostManagementCarDAO extends AbstractRdbDao {

    private FindCostManagementCarCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindCostManagementCarDAO() {
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
                Mbj05Car.DCARCD,
                Mbj05Car.CARNM,
                Tbj21Seisakuhi.SEISAKUHIS,
                Tbj21Seisakuhi.DCARNM,
                Tbj21Seisakuhi.SEISAKUHIOTHER,
                Tbj21Seisakuhi.BIKO,
                Tbj21Seisakuhi.GETTIME,
                Tbj21Seisakuhi.CRTDATE,
                Tbj21Seisakuhi.CRTNM,
                Tbj21Seisakuhi.CRTID,
                Tbj21Seisakuhi.UPDDATE,
                Tbj21Seisakuhi.UPDID
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

        tbl.append(Mbj05Car.TBNAME);
        tbl.append(", ");
        tbl.append("(SELECT * FROM ");
        tbl.append(Tbj21Seisakuhi.TBNAME);
        tbl.append(" WHERE ");
        tbl.append(Tbj21Seisakuhi.PHASE);
        tbl.append(" = ");
        tbl.append(_condition.getPhase());
        tbl.append(" AND ");
        tbl.append(Tbj21Seisakuhi.SEIKYUYM);
        tbl.append(" = TO_DATE('");
        tbl.append(_condition.getYearMonth());
        tbl.append("', 'YYYY/MM') ");
        tbl.append(") Tbj21");

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
        sql.append(Mbj05Car.DISPSTS);
        sql.append(" = '1' ");
        sql.append(" AND ");
        sql.append(Mbj05Car.DCARCD);
        sql.append(" = ");
        sql.append(Tbj21Seisakuhi.DCARCD);
        sql.append("(+) ");
        sql.append(" ORDER BY ");
        sql.append(Mbj05Car.SORTNO);
        sql.append(", ");
        sql.append(Mbj05Car.DCARCD);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindCostManagementCarVO> selectVO(FindCostManagementCarCondition condition) throws HAMException {

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindCostManagementCarVO());

        try {
            _condition = condition;
            return (List<FindCostManagementCarVO> ) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
