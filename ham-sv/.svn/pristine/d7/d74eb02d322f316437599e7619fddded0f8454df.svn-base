package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj21Calendar;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * カレンダーマスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj21CalendarDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Mbj21CalendarCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj21CalendarDAO() {
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
                Mbj21Calendar.DATAKBN
                ,Mbj21Calendar.CALENDARYM
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj21Calendar.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj21Calendar.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj21Calendar.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj21Calendar.DATAKBN
                ,Mbj21Calendar.CALENDARYM
                ,Mbj21Calendar.GAITOUM1
                ,Mbj21Calendar.GAITOUM2
                ,Mbj21Calendar.GAITOUM3
                ,Mbj21Calendar.GAITOUM4
                ,Mbj21Calendar.GAITOUM5
                ,Mbj21Calendar.GAITOUM6
                ,Mbj21Calendar.GAITOUM7
                ,Mbj21Calendar.GAITOUM8
                ,Mbj21Calendar.GAITOUM9
                ,Mbj21Calendar.GAITOUM10
                ,Mbj21Calendar.GAITOUM11
                ,Mbj21Calendar.GAITOUM12
                ,Mbj21Calendar.GAITOUM13
                ,Mbj21Calendar.GAITOUM14
                ,Mbj21Calendar.GAITOUM15
                ,Mbj21Calendar.GAITOUM16
                ,Mbj21Calendar.GAITOUM17
                ,Mbj21Calendar.GAITOUM18
                ,Mbj21Calendar.GAITOUM19
                ,Mbj21Calendar.GAITOUM20
                ,Mbj21Calendar.GAITOUM21
                ,Mbj21Calendar.GAITOUM22
                ,Mbj21Calendar.GAITOUM23
                ,Mbj21Calendar.GAITOUM24
                ,Mbj21Calendar.GAITOUM25
                ,Mbj21Calendar.GAITOUM26
                ,Mbj21Calendar.GAITOUM27
                ,Mbj21Calendar.GAITOUM28
                ,Mbj21Calendar.GAITOUM29
                ,Mbj21Calendar.GAITOUM30
                ,Mbj21Calendar.GAITOUM31
                ,Mbj21Calendar.UPDDATE
                ,Mbj21Calendar.UPDNM
                ,Mbj21Calendar.UPDAPL
                ,Mbj21Calendar.UPDID
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

        if (super.getModel() instanceof Mbj21CalendarVO)
        {
            // Mbj21CalendarVO取得用SQL取得
            sql = Mbj21CalendarVO();
        }

        return sql;

    };

    /**
     * SELECT SQL（Mbj21CalendarVO）
     */
    private String Mbj21CalendarVO() {
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
            Mbj21CalendarVO vo = new Mbj21CalendarVO();
            vo.setDATAKBN(_condition.getDatakbn());
            vo.setCALENDARYM(_condition.getCalendarym());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Mbj21Calendar.DATAKBN + " ");
        orderSql.append(", " + Mbj21Calendar.CALENDARYM + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj21CalendarVO> selectVO(Mbj21CalendarCondition condition) throws HAMException
    {
        // パラメータチェック
        if (condition == null)
        {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Mbj21CalendarVO());
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
