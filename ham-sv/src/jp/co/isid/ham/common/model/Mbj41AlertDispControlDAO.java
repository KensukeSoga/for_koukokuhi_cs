package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.ham.integ.tbl.Mbj02User;
import jp.co.isid.ham.integ.tbl.Mbj41AlertDispControl;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * アラート表示制御マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/05 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj41AlertDispControlDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Mbj41AlertDispControlCondition _condition = null;

    /** getExecSQLで発行するSQLのモード() */
    private enum ExecSqlMode { DELETE };
    private ExecSqlMode _ExecSqlMode = ExecSqlMode.DELETE;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj41AlertDispControlDAO() {
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
                Mbj41AlertDispControl.DISPTYPE
                ,Mbj41AlertDispControl.DCARCD
                ,Mbj41AlertDispControl.SEQNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj41AlertDispControl.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj41AlertDispControl.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj41AlertDispControl.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj41AlertDispControl.DISPTYPE
                ,Mbj41AlertDispControl.DCARCD
                ,Mbj41AlertDispControl.SEQNO
                ,Mbj41AlertDispControl.HAMID
                ,Mbj41AlertDispControl.SIKOGNZUNTCD
                ,Mbj41AlertDispControl.UPDDATE
                ,Mbj41AlertDispControl.UPDNM
                ,Mbj41AlertDispControl.UPDAPL
                ,Mbj41AlertDispControl.UPDID
        };
    }

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
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (super.getModel() instanceof Mbj41AlertDispControlWithUserVO) {
            // Mbj41AlertDispControlVO取得用SQL取得
            sql = getSelectSQLMbj41AlertDispControlWithUserVO();
        }
        else if (super.getModel() instanceof Mbj41AlertDispControlVO)
        {
            // Mbj41AlertDispControlVO取得用SQL取得
            sql = getSelectSQLMbj41AlertDispControlVO();
        }

        return sql;
    };

    /**
     * EXEC SQL
     */
    @Override
    public String getExecString() {

        String sql = "";

        if (_ExecSqlMode.equals(ExecSqlMode.DELETE)) {
            sql = getExecStringForDELETE();
        }

        return sql.toString();
    }

    /**
     * SELECT SQL（Mbj41AlertDispControlVO）
     */
    private String getSelectSQLMbj41AlertDispControlVO() {

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
            Mbj41AlertDispControlVO vo = new Mbj41AlertDispControlVO();
            vo.setDISPTYPE(_condition.getDisptype());
            vo.setDCARCD(_condition.getDcarcd());
            vo.setSEQNO(_condition.getSeqno());
            vo.setHAMID(_condition.getHamid());
            vo.setSIKOGNZUNTCD(_condition.getSikognzuntcd());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
            whereSqlStr = generateWhereByCond(vo);

        }

        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Mbj41AlertDispControl.DISPTYPE + "," + Mbj41AlertDispControl.DCARCD + "," + Mbj41AlertDispControl.SEQNO + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * SELECT SQL（Mbj41AlertDispControlWithUserVO）
     */
    private String getSelectSQLMbj41AlertDispControlWithUserVO() {

        StringBuffer selectSql = new StringBuffer();
        StringBuffer whereSqlStr = new StringBuffer();
        StringBuffer orderSql = new StringBuffer();

        //*******************************************
        //load()、find()で使用されるSELECT + FROM句のSQL
        //*******************************************
        selectSql.append(" SELECT ");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }
        selectSql.append("," + Mbj02User.USERNAME1 + " ");
        selectSql.append("," + Mbj02User.USERNAME2 + " ");
        selectSql.append(" FROM ");
        selectSql.append(" " + getTableName() + " ");
        selectSql.append("," + Mbj02User.TBNAME + " ");

        if (_condition != null) {
            Mbj41AlertDispControlVO vo = new Mbj41AlertDispControlVO();
            vo.setDISPTYPE(_condition.getDisptype());
            vo.setDCARCD(_condition.getDcarcd());
            vo.setSEQNO(_condition.getSeqno());
            vo.setHAMID(_condition.getHamid());
            vo.setSIKOGNZUNTCD(_condition.getSikognzuntcd());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
            whereSqlStr.append(generateWhereByCond(vo));
        }
        if (whereSqlStr.length() == 0) {
            whereSqlStr.append(" WHERE ");
        } else {
            whereSqlStr.append(" AND ");
        }
        whereSqlStr.append(Mbj41AlertDispControl.HAMID);
        whereSqlStr.append(" = ");
        whereSqlStr.append(Mbj02User.HAMID);

        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Mbj41AlertDispControl.DISPTYPE + "," + Mbj41AlertDispControl.DCARCD + "," + Mbj41AlertDispControl.SEQNO + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * DELETE SQL（プライマリキー以外指定）
     */
    private String getExecStringForDELETE() {

        StringBuffer deleteSql = new StringBuffer();
        String whereSqlStr = "";

        deleteSql.append(" DELETE ");
        deleteSql.append(" FROM ");
        deleteSql.append(" " + getTableName() + " ");

        whereSqlStr = generateWhereByCond(super.getModel());

        return deleteSql.toString() + whereSqlStr;
    };

    /**
     * InsertVO
     * @param vo データ
     * @throws HAMException
     */
    public void insertVO(Mbj41AlertDispControlVO vo) throws HAMException {

        // パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);

        try {
            if (!super.insert())
            {
                throw new HAMException("登録エラー", "BJ-E0002");
            }
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * UpdateVO
     * @param vo データ
     * @throws HAMException
     */
    public void updateVO(Mbj41AlertDispControlVO vo) throws HAMException {

        // パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);

        try {
            if (!super.update()) {
                throw new HAMException("更新エラー", "BJ-E0003");
            }
        }
        catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * DeleteVO
     * @param vo データ
     * @throws HAMException
     */
    public void deleteVO(Mbj41AlertDispControlVO vo) throws HAMException {

        // パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);

        try {
            if (!super.remove()) {
                throw new HAMException("削除エラー", "BJ-E0004");
            }
        } catch(ConcurrentUpdateException e) {
            // 処理件数「0」の場合
            return;   // 正常とする（削除レコードなし）
        } catch(UpdateFailureException e) {
            // 処理件数「2以上」の場合
            return;   // 正常とする
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * DeleteVO（プライマリキー以外指定）
     * @param vo データ
     * @throws HAMException
     */
    public void deleteVOWhereNoPrimaryKey(Mbj41AlertDispControlVO vo) throws HAMException {

        // パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);
        _ExecSqlMode = ExecSqlMode.DELETE;

        try {
            super.exec();
        } catch(UserException e) {
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
    public List<Mbj41AlertDispControlVO> selectVO(Mbj41AlertDispControlCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Mbj41AlertDispControlVO());
        _condition = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj41AlertDispControlWithUserVO> selectVOWithUserNm(Mbj41AlertDispControlCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Mbj41AlertDispControlWithUserVO());
        _condition = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
