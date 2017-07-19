package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.ham.integ.tbl.Mbj42Security;
import jp.co.isid.ham.integ.tbl.Mbj44SecurityBase;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * セキュリティベースマスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/19 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj44SecurityBaseDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Mbj44SecurityBaseCondition _condition = null;

    private enum SqlMode{SINGLE,MANY};
    private SqlMode _sqlMode = SqlMode.SINGLE;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj44SecurityBaseDAO() {
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
                Mbj44SecurityBase.KKSIKOGNZUNTCD
                ,Mbj44SecurityBase.USERTYPE
                ,Mbj44SecurityBase.SECURITYCD
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj44SecurityBase.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj44SecurityBase.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj44SecurityBase.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj44SecurityBase.KKSIKOGNZUNTCD
                ,Mbj44SecurityBase.USERTYPE
                ,Mbj44SecurityBase.SECURITYCD
                ,Mbj44SecurityBase.SECURITYTYPE
                ,Mbj44SecurityBase.UPDATE
                ,Mbj44SecurityBase.CHECK
                ,Mbj44SecurityBase.REFERENCE
                ,Mbj44SecurityBase.UPDDATE
                ,Mbj44SecurityBase.UPDNM
                ,Mbj44SecurityBase.UPDAPL
                ,Mbj44SecurityBase.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL()
    {
        String sql = "";

//        if (super.getModel() instanceof Mbj44SecurityBaseVO)
//        {
//            // Mbj44SecurityBaseVO取得用SQL取得
//            sql = getSelectSQLMbj44SecurityBaseVO();
//        }

        if (_sqlMode.equals(SqlMode.SINGLE)) {
            sql = getSelectSQLMbj44SecurityBaseVO();
        } else if (_sqlMode.equals(SqlMode.MANY)) {
            sql = getManyCd();
        }

        return sql;

    };

    /**
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo)
    {
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
     * SELECT SQL（Mbj44SecurityBaseVO）
     */
    private String getSelectSQLMbj44SecurityBaseVO()
    {
        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";
        StringBuffer orderSql = new StringBuffer();

        //*******************************************
        //load()、find()で使用されるSELECT + FROM句のSQL
        //*******************************************
        selectSql.append(" SELECT ");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }
        selectSql.append(" FROM ");
        selectSql.append(" " + getTableName() + " ");

        if (_condition != null)
        {
            Mbj44SecurityBaseVO vo = new Mbj44SecurityBaseVO();
            vo.setKKSIKOGNZUNTCD(_condition.getKksikognzuntcd());
            vo.setUSERTYPE(_condition.getUsertype());
            vo.setSECURITYCD(_condition.getSecuritycd());
            vo.setSECURITYTYPE(_condition.getSecuritytype());
            vo.setUPDATE(_condition.getUpdate());
            vo.setCHECK(_condition.getCheck());
            vo.setREFERENCE(_condition.getReference());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
            whereSqlStr = generateWhereByCond(vo);

        }

        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Mbj44SecurityBase.KKSIKOGNZUNTCD + "," + Mbj44SecurityBase.USERTYPE + "," + Mbj44SecurityBase.SECURITYCD + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * SELECT SQL(複数コード取得用)
     * @return
     */
    private String getManyCd() {

        StringBuffer selectSql = new StringBuffer();
//        String whereSqlStr = "";
        StringBuffer orderSql = new StringBuffer();

        //*******************************************
        //load()、find()で使用されるSELECT + FROM句のSQL
        //*******************************************
        selectSql.append(" SELECT ");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }
        selectSql.append(" FROM ");
        selectSql.append(" " + getTableName() + " ");

        Mbj42SecurityVO vo = new Mbj42SecurityVO();

        if (_condition != null)
        {
            vo.setHAMID(_condition.getUpdid());
            vo.setSECURITYCD(_condition.getSecuritycd());
            vo.setSECURITYTYPE(_condition.getSecuritytype());
            vo.setUPDATE(_condition.getUpdate());
            vo.setCHECK(_condition.getCheck());
            vo.setREFERENCE(_condition.getReference());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
//            whereSqlStr = generateWhereByCond2(vo);
        }
        orderSql.append(" WHERE ");
        orderSql.append(" " + Mbj42Security.SECURITYCD + " IN(" + _condition.getSecuritycd() + ") ");
        orderSql.append(" AND ");
        orderSql.append(" " + Mbj42Security.HAMID+ " = '" + _condition.getUpdid() + "' ");
        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Mbj42Security.HAMID + "," + Mbj42Security.SECURITYCD + " ");

//        return selectSql.toString() + whereSqlStr + orderSql.toString();
        return selectSql.toString() + orderSql.toString();
    }

    /**
     * InsertVO
     * @param vo データ
     * @throws HAMException
     */
    public void insertVO(Mbj44SecurityBaseVO vo) throws HAMException
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
    public void updateVO(Mbj44SecurityBaseVO vo) throws HAMException
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
    public void deleteVO(Mbj44SecurityBaseVO vo) throws HAMException
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
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj44SecurityBaseVO> selectVO(Mbj44SecurityBaseCondition condition) throws HAMException
    {
        // パラメータチェック
        if (condition == null)
        {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Mbj44SecurityBaseVO());
        _condition = condition;

        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 複数のコードで検索を行う
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj44SecurityBaseVO> FindManyCd(Mbj44SecurityBaseCondition condition) throws HAMException
    {
        // パラメータチェック
        if (condition == null)
        {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Mbj44SecurityBaseVO());
        _condition = condition;
        _sqlMode = SqlMode.MANY;
        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
