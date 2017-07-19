package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.ham.integ.tbl.Mbj29SetteiKyk;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 設定局マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj29SetteiKykDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Mbj29SetteiKykCondition _condition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode {
        LOAD, VO
    };

    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj29SetteiKykDAO() {
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
                Mbj29SetteiKyk.PHASE
                ,Mbj29SetteiKyk.STKYKNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj29SetteiKyk.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj29SetteiKyk.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj29SetteiKyk.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj29SetteiKyk.PHASE
                ,Mbj29SetteiKyk.STKYKNO
                ,Mbj29SetteiKyk.STKYKNM
                ,Mbj29SetteiKyk.SIKCD
                ,Mbj29SetteiKyk.SSSFLG
                ,Mbj29SetteiKyk.MAILFLG
                ,Mbj29SetteiKyk.SORTNO
                ,Mbj29SetteiKyk.UPDDATE
                ,Mbj29SetteiKyk.UPDNM
                ,Mbj29SetteiKyk.UPDAPL
                ,Mbj29SetteiKyk.UPDID
        };
    }



    /**
     * デフォルトのSQL文を返します
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
            if (_condition != null)
            {
                Mbj29SetteiKykVO vo = new Mbj29SetteiKykVO();
                vo.setPHASE(_condition.getPhase());
                vo.setSTKYKNO(_condition.getStkykno());
                vo.setSTKYKNM(_condition.getStkyknm());
                vo.setSIKCD(_condition.getSikcd());
                vo.setSSSFLG(_condition.getSssflg());
                vo.setMAILFLG(_condition.getMailflg());
                vo.setSORTNO(_condition.getSortno());
                vo.setUPDDATE(_condition.getUpddate());
                vo.setUPDNM(_condition.getUpdnm());
                vo.setUPDAPL(_condition.getUpdapl());
                vo.setUPDID(_condition.getUpdid());

                whereSql.append(generateWhereByCond(vo));
            }

            orderSql.append(" ORDER BY ");
            orderSql.append(" " + Mbj29SetteiKyk.SORTNO + "," + Mbj29SetteiKyk.STKYKNO + " ");

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
     * InsertVO
     * @param vo データ
     * @throws HAMException
     */
    public void insertVO(Mbj29SetteiKykVO vo) throws HAMException
    {
        // パラメータチェック
        if (vo == null)
        {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);

        try
        {
            if (!super.insert())
            {
                throw new HAMException("登録エラー", "BJ-E0002");
            }
        }
        catch(UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }

    }

    /**
     * UpdateVO
     * @param vo データ
     * @throws HAMException
     */
    public void updateVO(Mbj29SetteiKykVO vo) throws HAMException
    {
        // パラメータチェック
        if (vo == null)
        {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);

        try
        {
            if (!super.update())
            {
                throw new HAMException("更新エラー", "BJ-E0003");
            }
        }
        catch(UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }

    }

    /**
     * DeleteVO
     * @param vo データ
     * @throws HAMException
     */
    public void deleteVO(Mbj29SetteiKykVO vo) throws HAMException
    {
        // パラメータチェック
        if (vo == null)
        {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);

        try
        {
            if (!super.remove())
            {
                throw new HAMException("削除エラー", "BJ-E0004");
            }
        }
        catch(ConcurrentUpdateException e)
        {   // 処理件数「0」の場合
            return;   // 正常とする（削除レコードなし）
        }
        catch(UpdateFailureException e)
        {   // 処理件数「2以上」の場合
            return;   // 正常とする
        }
        catch(UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }

    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj29SetteiKykVO> selectVO(Mbj29SetteiKykCondition condition) throws HAMException {

      super.setModel(new Mbj29SetteiKykVO());
      try {
          _SelSqlMode = SelSqlMode.VO;
          _condition = condition;
          return (List<Mbj29SetteiKykVO>)super.find();
      } catch (UserException e) {
          throw new HAMException(e.getMessage(), "BJ-E0001");
      }
    }

}
