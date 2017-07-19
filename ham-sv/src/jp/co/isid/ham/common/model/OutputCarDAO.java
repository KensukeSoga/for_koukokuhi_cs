package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj13CarOutCtrl;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 車種出力設定マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/09 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class OutputCarDAO extends AbstractSimpleRdbDao{

    /** 検索条件 */
    private FindExcelOutSettingCondition _cond = null;
    private String _searchCar;

    private enum SqlMode{DEFAULT,REPORTOUT};
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /**
     * デフォルトコンストラクタ
     */
    public OutputCarDAO() {
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
        return Mbj13CarOutCtrl.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj13CarOutCtrl.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj13CarOutCtrl.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj13CarOutCtrl.REPORTCD
                ,Mbj13CarOutCtrl.DCARCD
                ,Mbj05Car.CARNM
                ,Mbj13CarOutCtrl.OUTPUTFLG
                ,Mbj13CarOutCtrl.SORTNO
                ,Mbj05Car.SORTNO
                ,Mbj13CarOutCtrl.PHASE
                ,Mbj13CarOutCtrl.UPDDATE
                ,Mbj13CarOutCtrl.UPDNM
                ,Mbj13CarOutCtrl.UPDAPL
                ,Mbj13CarOutCtrl.UPDID
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {
        if (_sqlMode.equals(SqlMode.DEFAULT)) {
            return getOutputCarList();
        } else if (_sqlMode.equals(SqlMode.REPORTOUT)) {
            return getOutputReportCarList();
        } else {
            return null;
        }
    }


    /**
     * 車種＆権限のSQL文を返します
     *
     * @return String SQL文
     */
    private String getOutputCarList() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" "+ Mbj13CarOutCtrl.TBNAME + ", ");
        sql.append(" "+ Mbj05Car.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" "+ Mbj05Car.DISPSTS + " = '1' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.DCARCD+ " = " + Mbj05Car.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.REPORTCD + " = '" + _cond.getReportcd() + "' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.OUTPUTFLG + " = '1' ");
        sql.append(" ORDER BY ");
        sql.append(" "+ Mbj13CarOutCtrl.OUTPUTFLG + " ASC, ");
        sql.append(" "+ Mbj13CarOutCtrl.SORTNO + " ASC, ");
        sql.append(" " + Mbj05Car.SORTNO + " ASC ");

        return sql.toString();
    }

    /**
     * 車種＆権限のSQL文を返します
     *
     * @return String SQL文
     */
    private String getOutputReportCarList() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" "+ Mbj13CarOutCtrl.TBNAME + ", ");
        sql.append(" "+ Mbj05Car.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" "+ Mbj05Car.DISPSTS + " = '1' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.DCARCD+ " = " + Mbj05Car.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.REPORTCD + " = '" + _cond.getReportcd() + "' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.OUTPUTFLG + " = '1' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.DCARCD + " IN(" + _searchCar + ")");
        sql.append(" ORDER BY ");
        sql.append(" "+ Mbj13CarOutCtrl.OUTPUTFLG + " ASC, ");
        sql.append(" "+ Mbj13CarOutCtrl.SORTNO + " ASC, ");
        sql.append(" " + Mbj05Car.SORTNO + " ASC ");

        return sql.toString();
    }

    /**
     * 帳票出力媒体の検索を行います
     *
     * @return 帳票出力媒体VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<OutputCarVO> findOutputCarList(
            FindExcelOutSettingCondition cond) throws HAMException {

        super.setModel(new OutputCarVO());

        try {
            _cond = cond;
            _sqlMode = SqlMode.DEFAULT;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 帳票出力媒体の検索を行います
     *
     * @return 帳票出力媒体VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<OutputCarVO> findOutputReportCarList(
            FindExcelOutSettingCondition cond,String searchCar) throws HAMException {

        super.setModel(new OutputCarVO());

        try {
            _cond = cond;
            _sqlMode = SqlMode.REPORTOUT;
            _searchCar = searchCar;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
