package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj15CmCode;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 自動採番DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj15CmCodeDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj15CmCodeCondition _condition = null;

    /** SQLモード */
    private enum SqlMode { FIND, INS, UPD };
    private SqlMode _sqlMode = SqlMode.FIND;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj15CmCodeDAO() {
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
                Tbj15CmCode.NOKBN
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj15CmCode.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        if (_sqlMode.equals(SqlMode.INS)) {
            return new String[] {
                  Tbj15CmCode.CRTDATE
                  ,Tbj15CmCode.UPDDATE
            };
        } else if (_sqlMode.equals(SqlMode.UPD)) {
            return new String[] {
                    Tbj15CmCode.UPDDATE
            };
        } else {
            return new String[] { };
        }
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj15CmCode.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj15CmCode.NOKBN
                ,Tbj15CmCode.CNTKBN
                ,Tbj15CmCode.STARTNO
                ,Tbj15CmCode.EXISTNO
                ,Tbj15CmCode.BIKO
                ,Tbj15CmCode.CRTDATE
                ,Tbj15CmCode.CRTNM
                ,Tbj15CmCode.CRTAPL
                ,Tbj15CmCode.CRTID
                ,Tbj15CmCode.UPDDATE
                ,Tbj15CmCode.UPDNM
                ,Tbj15CmCode.UPDAPL
                ,Tbj15CmCode.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        return getSelectSortedSQL();
    }

    /**
     * 検索SQLを取得します
     * @return
     */
    private String getSelectSortedSQL() {

        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");

        for (int i = 0;i < getTableColumnNames().length;i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length -1) {
                sql.append(",");
            }
        }

        sql.append(" FROM ");
        sql.append("  " + getTableName());


        if (_condition != null)
        {
            Tbj15CmCodeVO vo = new Tbj15CmCodeVO();
            vo.setNOKBN(_condition.getNokbn());
            sql.append(this.generateWhereByCond(vo));

        }

        sql.append(" ORDER BY " + Tbj15CmCode.NOKBN);

        return sql.toString();
    }

    /**
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo)
    {
        StringBuffer sql = new StringBuffer();

        for (String colName : getTableColumnNames()) {
            Object value = vo.get(colName);
            if (value != null) {

                if (sql.length() == 0)
                    sql.append(" WHERE ");
                else
                    sql.append(" AND ");

                sql.append(colName + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj15CmCodeVO> selectVO(Tbj15CmCodeCondition condition) throws HAMException
    {
        // パラメータチェック
        if (condition == null)
        {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj15CmCodeVO());
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
     * UpdateVO
     * @param vo データ
     * @throws HAMException
     */
    public void updateVO(Tbj15CmCodeVO vo) throws HAMException
    {
        // パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }

        super.setModel(vo);
        _sqlMode = SqlMode.UPD;

        try
        {
            if (!super.update())
                throw new HAMException("更新エラー", "BJ-E0003");
        }
        catch(UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }

    }


}
