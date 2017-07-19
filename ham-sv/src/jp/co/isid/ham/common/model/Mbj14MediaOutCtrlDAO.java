package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj14MediaOutCtrl;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 媒体出力設定マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj14MediaOutCtrlDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Mbj14MediaOutCtrlCondition _condition = null;

    /** 削除条件 */
    private Mbj14MediaOutCtrlVO _delVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj14MediaOutCtrlDAO() {
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
        return null;
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj14MediaOutCtrl.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj14MediaOutCtrl.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj14MediaOutCtrl.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj14MediaOutCtrl.REPORTCD
                ,Mbj14MediaOutCtrl.MEDIACD
                ,Mbj14MediaOutCtrl.OUTPUTFLG
                ,Mbj14MediaOutCtrl.SORTNO
                ,Mbj14MediaOutCtrl.PHASE
                ,Mbj14MediaOutCtrl.UPDDATE
                ,Mbj14MediaOutCtrl.UPDNM
                ,Mbj14MediaOutCtrl.UPDAPL
                ,Mbj14MediaOutCtrl.UPDID
        };
    }

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
     * SELECT SQL
     */
    @Override
    public String getSelectSQL()
    {
        String sql = "";

        if (super.getModel() instanceof Mbj14MediaOutCtrlVO)
        {
            // Mbj14MediaOutCtrlVO取得用SQL取得
            sql = getSelectSQLMbj14MediaOutCtrlVO();
        }

        return sql;

    };

    /**
     * EXEC SQL
     */
    @Override
    public String getExecString()
    {
        String sql = "";

        if (_delVO != null)
        {
            // Mbj14MediaOutCtrlVO削除用SQL取得
            sql = getDeleteSQLMbj14MediaOutCtrlVO();
        }

        return sql;

    };

    /**
     * SELECT SQL（Mbj14MediaOutCtrlVO）
     */
    private String getSelectSQLMbj14MediaOutCtrlVO()
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
            Mbj14MediaOutCtrlVO vo = new Mbj14MediaOutCtrlVO();
            vo.setREPORTCD(_condition.getReportcd());
            vo.setMEDIACD(_condition.getMediacd());
            vo.setOUTPUTFLG(_condition.getOutputflg());
            vo.setSORTNO(_condition.getSortno());
            vo.setPHASE(_condition.getPhase());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Mbj14MediaOutCtrl.SORTNO + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * DELETE SQL（Mbj14MediaOutCtrlVO）
     */
    private String getDeleteSQLMbj14MediaOutCtrlVO()
    {
        StringBuffer deleteSql = new StringBuffer();
        String whereSqlStr = "";

        deleteSql.append(" DELETE ");
        deleteSql.append(" FROM ");
        deleteSql.append(" " + getTableName() + " ");

        if (_delVO != null)
        {
            whereSqlStr = generateWhereByCond(_delVO);
        }

        return deleteSql.toString() + whereSqlStr;
    };

    /**
     * InsertVO
     * @param vo データ
     * @throws HAMException
     */
    public void insertVO(Mbj14MediaOutCtrlVO vo) throws HAMException
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
    public void updateVO(Mbj14MediaOutCtrlVO vo) throws HAMException
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
    public void deleteVO(Mbj14MediaOutCtrlVO vo) throws HAMException
    {
        // パラメータチェック
        if (vo == null)
        {
            throw new HAMException("削除エラー", "BJ-E0004");
        }

        // プライマリキーがないためremove()が使えないので、削除処理を独自実装
        _delVO = vo;

        try
        {
            super.exec();   // exec()で削除処理を実行する
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
    public List<Mbj14MediaOutCtrlVO> selectVO(Mbj14MediaOutCtrlCondition condition) throws HAMException
    {
        // パラメータチェック
        if (condition == null)
        {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Mbj14MediaOutCtrlVO());
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

}
