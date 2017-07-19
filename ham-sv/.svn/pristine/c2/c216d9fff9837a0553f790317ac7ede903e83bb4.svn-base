package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR予算費目マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj16CrExpenceDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
//    private Mbj16CrExpenceCondition _condition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{VO,};
    private SelSqlMode _SelSqlMode = SelSqlMode.VO;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj16CrExpenceDAO() {
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
                Mbj16CrExpence.EXPCD
                ,Mbj16CrExpence.CLASSDIV
                ,Mbj16CrExpence.DATEFROM
                ,Mbj16CrExpence.DATETO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj16CrExpence.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj16CrExpence.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj16CrExpence.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj16CrExpence.EXPCD
                ,Mbj16CrExpence.CLASSDIV
                ,Mbj16CrExpence.DATEFROM
                ,Mbj16CrExpence.DATETO
                ,Mbj16CrExpence.EXPNM
                ,Mbj16CrExpence.SORTNO
                ,Mbj16CrExpence.FLG1
                ,Mbj16CrExpence.UPDDATE
                ,Mbj16CrExpence.UPDNM
                ,Mbj16CrExpence.UPDAPL
                ,Mbj16CrExpence.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        StringBuffer selectSql = new StringBuffer();
        StringBuffer whereSql = new StringBuffer();
        StringBuffer orderSql = new StringBuffer();

        if (_SelSqlMode.equals(SelSqlMode.VO)) {

            //*******************************************
            //selectVOで使用されるSELECT + FROM句のSQL
            //*******************************************
            selectSql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                selectSql.append((i != 0 ? " ," : " "));
                selectSql.append("" + getTableColumnNames()[i] +" ");
            }
            selectSql.append(" FROM ");
            selectSql.append(" " + getTableName() + " ");
            //WHERE句
            whereSql.append(generateWhereByCond(getModel()));
            //ORDER句
            orderSql.append(" ORDER BY ");
            orderSql.append("     " + Mbj16CrExpence.SORTNO + " ");
            orderSql.append("    ," + Mbj16CrExpence.CLASSDIV + " ");
        }

        return selectSql.toString() + whereSql.toString() + orderSql.toString();
    };

    /**
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
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
                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj16CrExpenceVO> selectVO(Mbj16CrExpenceVO vo) throws HAMException {

      super.setModel(vo);
      try {
          _SelSqlMode = SelSqlMode.VO;
          return (List<Mbj16CrExpenceVO>)super.find();
      } catch (UserException e) {
          throw new HAMException(e.getMessage(), "BJ-E0001");
      }
    }
}
