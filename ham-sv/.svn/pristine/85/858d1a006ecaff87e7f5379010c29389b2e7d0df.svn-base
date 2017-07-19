package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * H新モデルコスト合計取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/10 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindSumHmCostDAO extends AbstractRdbDao {

    FindSumHmCostCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindSumHmCostDAO() {
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
        return new String[] {
                Tbj02EigyoDaicho.DCARCD
                ,"MIN(" + Mbj05Car.CARNM + ") " + Mbj05Car.CARNM
                ,Tbj02EigyoDaicho.MEDIACD
                ,"MIN(" + Mbj03Media.MEDIANM + ") " + Mbj03Media.MEDIANM
                ,"SUM(" + Tbj02EigyoDaicho.HMCOST + ") " + Tbj02EigyoDaicho.HMCOST
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

        tbl.append(Tbj02EigyoDaicho.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj05Car.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj03Media.TBNAME);

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
        sql.append(Tbj02EigyoDaicho.SEIKYUYM);
        sql.append(" >= ");
        sql.append("TO_DATE('");
        sql.append(_condition.getYearMonth());
        sql.append("', 'YYYY/MM')");
        sql.append(" AND ");
        sql.append(Tbj02EigyoDaicho.SEIKYUYM);
        sql.append(" < ");
        sql.append("ADD_MONTHS(TO_DATE('");
        sql.append(_condition.getYearMonth());
        sql.append("', 'YYYY/MM'), 1)");


        if (_condition.getDCarCd() != null && _condition.getDCarCd().size() > 0) {
            sql.append(" AND ");
            sql.append(Tbj02EigyoDaicho.DCARCD);
            sql.append(" IN ");
            sql.append("(");
            for (int i = 0; i <  _condition.getDCarCd().size(); i++) {
                sql.append("'");
                sql.append( _condition.getDCarCd().get(i));
                sql.append("'");
                if (i < _condition.getDCarCd().size()-1) {
                    sql.append(", ");
                }
            }
            sql.append(")");
        }

        if (_condition.getMediaCd() != null && _condition.getMediaCd().size() > 0) {
            sql.append(" AND ");
            sql.append(Tbj02EigyoDaicho.MEDIACD);
            sql.append(" IN ");
            sql.append("(");
            for (int i = 0; i <  _condition.getMediaCd().size(); i++) {
                sql.append("'");
                sql.append( _condition.getMediaCd().get(i));
                sql.append("'");
                if (i < _condition.getMediaCd().size()-1) {
                    sql.append(", ");
                }
            }
            sql.append(")");
        }

        sql.append(" AND ");
        sql.append(Tbj02EigyoDaicho.DCARCD);
        sql.append(" = ");
        sql.append(Mbj05Car.DCARCD);
        sql.append("(+)");

        sql.append(" AND ");
        sql.append(Tbj02EigyoDaicho.MEDIACD);
        sql.append(" = ");
        sql.append(Mbj03Media.MEDIACD);
        sql.append("(+)");

        sql.append(" GROUP BY ");
        sql.append(Tbj02EigyoDaicho.DCARCD);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.MEDIACD);

        sql.append(" ORDER BY ");
        sql.append("MIN(");
        sql.append(Mbj05Car.SORTNO);
        sql.append(")");
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.DCARCD);

        return sql.toString();
    }

    /**
     * 検索条件を設定する
     *
     * @param condition 検索条件
     */
    public void setCondition(FindSumHmCostCondition condition) {
        _condition = condition;
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindSumHmCostVO> selectVO() throws HAMException {
        //パラメータチェック
        if (_condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindSumHmCostVO());
        try
        {
            return (List<FindSumHmCostVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
