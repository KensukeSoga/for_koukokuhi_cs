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
 * 帳票に出力しない車種取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/09 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class CarNotOutDAO extends AbstractSimpleRdbDao{

    /** 検索条件 */
    private FindExcelOutSettingCondition _cond = null;

    /**
     * デフォルトコンストラクタ
     */
    public CarNotOutDAO() {
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
                Mbj05Car.DCARCD
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj05Car.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj05Car.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj05Car.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj05Car.DCARCD
                ,Mbj05Car.KEIRETSUCD
                ,Mbj05Car.CARNM
                ,Mbj05Car.DISPSTS
                ,Mbj05Car.SORTNO
                ,Mbj05Car.UPDDATE
                ,Mbj05Car.UPDNM
                ,Mbj05Car.UPDAPL
                ,Mbj05Car.UPDID
        };
    }


    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        return getNotOutCarList();
    }


    /**
     * 帳票に出力しない媒体を検索します
     *
     * @return String SQL文
     */
    private String getNotOutCarList() {
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
        sql.append(" "+ Mbj05Car.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" "+ Mbj05Car.DISPSTS + " = '1' ");
        sql.append(" AND ");
        sql.append(" NOT EXISTS(SELECT ");
        sql.append(" " + Mbj13CarOutCtrl.DCARCD + " ");
        sql.append(" FROM ");
        sql.append(" "+ Mbj13CarOutCtrl.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Mbj05Car.DCARCD + " = " + Mbj13CarOutCtrl.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.REPORTCD + " = '" + _cond.getReportcd() + "' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.OUTPUTFLG + " = '1' ");
        sql.append(" ) ");
        sql.append(" ORDER BY ");
        sql.append(" " + Mbj05Car.SORTNO + " ASC ");
        sql.append("," + Mbj05Car.KEIRETSUCD + " ASC ");
        sql.append("," + Mbj05Car.DCARCD + " ASC ");

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
    public List<Mbj05CarVO> findNotOutCarList(
            FindExcelOutSettingCondition cond) throws HAMException {

        super.setModel(new Mbj05CarVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
