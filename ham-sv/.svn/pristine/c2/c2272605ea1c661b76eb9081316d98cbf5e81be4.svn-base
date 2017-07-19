package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj01MediaPlan;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

public class FindAccountBookSortNoDAO extends AbstractRdbDao {

    FindAccountBookSortNoCondition _cond = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindAccountBookSortNoDAO() {
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
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return null;
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
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        sql.append("NVL(MAX(");
        sql.append(Tbj02EigyoDaicho.SORTNO);
        sql.append("), 0) + 1 AS SORTNO");

        sql.append(" FROM ");

        sql.append("(");
        sql.append("SELECT ");
        sql.append(Tbj01MediaPlan.PHASE);
        sql.append(" AS MYPHASE");
        sql.append(" FROM ");
        sql.append(Tbj01MediaPlan.TBNAME);
        sql.append(" WHERE ");
        sql.append(Tbj01MediaPlan.MEDIAPLANNO);
        sql.append(" = ");
        sql.append(_cond.getMEDIAPLANNO());
        sql.append(") X");

        sql.append(", ");
        sql.append(Tbj01MediaPlan.TBNAME);

        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.TBNAME);

        sql.append(" WHERE ");
        sql.append(Tbj01MediaPlan.PHASE);
        sql.append(" = ");
        sql.append(" MYPHASE");
        sql.append(" AND ");
        sql.append(Tbj01MediaPlan.MEDIAPLANNO);
        sql.append(" = ");
        sql.append(Tbj02EigyoDaicho.MEDIAPLANNO);


        return sql.toString();
    }

    /**
     * ソート順を取得する
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindAccountBookSortNoVO> selectVO(FindAccountBookSortNoCondition cond) throws HAMException {

        super.setModel(new FindAccountBookSortNoVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
