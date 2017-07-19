package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj15CrClass;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR予算分類マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj15CrClassDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
 //   private Mbj15CrClassCondition _condition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{LOAD, VO, DATE,};
    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj15CrClassDAO() {
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
                Mbj15CrClass.CLASSCD
                ,Mbj15CrClass.DATEFROM
                ,Mbj15CrClass.DATETO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj15CrClass.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj15CrClass.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj15CrClass.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj15CrClass.CLASSCD
                ,Mbj15CrClass.DATEFROM
                ,Mbj15CrClass.DATETO
                ,Mbj15CrClass.CLASSNM
                ,Mbj15CrClass.SORTNO
                ,Mbj15CrClass.UPDDATE
                ,Mbj15CrClass.UPDNM
                ,Mbj15CrClass.UPDAPL
                ,Mbj15CrClass.UPDID
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

        if (_SelSqlMode.equals(SelSqlMode.LOAD)) {

            //*******************************************
            //Load()で使用されるSELECT + FROM句のSQL
            //*******************************************
            selectSql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                selectSql.append((i != 0 ? " ," : " "));
                selectSql.append("" + getTableColumnNames()[i] +" ");
            }
            selectSql.append(" FROM ");
            selectSql.append(" " + getTableName() + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.VO)) {

            //*******************************************
            //selectVOで使用されるSQL
            //*******************************************
            //SELECT + FROM句
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
            orderSql.append("     " + Mbj15CrClass.SORTNO + " ");
            orderSql.append("    ," + Mbj15CrClass.CLASSCD + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.DATE)) {

            //*******************************************
            //selectVOByDateで使用されるSQL
            //*******************************************
            Mbj15CrClassVO cond = (Mbj15CrClassVO)super.getModel();

            //SELECT + FROM句
            selectSql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                selectSql.append((i != 0 ? " ," : " "));
                selectSql.append("" + getTableColumnNames()[i] +" ");
            }
            selectSql.append(" FROM ");
            selectSql.append(" " + getTableName() + " ");

            //WHERE句
            whereSql.append(" WHERE ");
            whereSql.append("     " + Mbj15CrClass.DATEFROM  +" <= " + super.getDBModelInterface().getDateString(cond.getDATEFROM())  + " ");
            whereSql.append(" AND " + Mbj15CrClass.DATETO  +" >= " + super.getDBModelInterface().getDateString(cond.getDATETO())  + " ");

            //ORDER句
            orderSql.append(" ORDER BY ");
            orderSql.append("     " + Mbj15CrClass.SORTNO + " ");
            orderSql.append("    ," + Mbj15CrClass.CLASSCD + " ");

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
    public List<Mbj15CrClassVO> selectVO(Mbj15CrClassVO vo) throws HAMException {

      super.setModel(vo);
      try {
          _SelSqlMode = SelSqlMode.VO;
          return (List<Mbj15CrClassVO>)super.find();
      } catch (UserException e) {
          throw new HAMException(e.getMessage(), "BJ-E0001");
      }
    }

    /**
     * 有効期間内のデータを全て取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj15CrClassVO> selectVOByDate(Mbj15CrClassVO cond) throws HAMException {
      //パラメータチェック
      if (cond == null) {
          throw new HAMException("検索エラー", "BJ-E0001");
      }
      super.setModel(cond);
      try {
          _SelSqlMode = SelSqlMode.DATE;
          return (List<Mbj15CrClassVO>)super.find();
      } catch (UserException e) {
          throw new HAMException(e.getMessage(), "BJ-E0001");
      }
    }



//▼▼▼CR予算分類マスタでは未使用の予定------------------------------------------------------▼▼▼
    /**
     * PK検索
     * @param cond
     * @return
     * @throws HAMException
     */
    public Mbj15CrClassVO loadVO(Mbj15CrClassVO cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            return (Mbj15CrClassVO)super.load();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 登録
     * @param vo
     * @return
     * @throws HAMException
     */
    public void insertVO(Mbj15CrClassVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            super.insert();
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
    public void updateVO(Mbj15CrClassVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            super.update();
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
    public void deleteVO(Mbj15CrClassVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);
        try {
            super.remove();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }
//▲▲▲CR予算分類マスタでは未使用の予定------------------------------------------------------▲▲▲

}
