package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMea10Irsk;
import jp.co.isid.ham.integ.tbl.RepaVbjaMea11DisplayIrsk;
import jp.co.isid.ham.integ.tbl.RepaVbjaMea12DisplayGyomKbn;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu07SikKrSprd;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu29Cc;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* ファイル出力用に組織データを検索
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/02/19 HLC H.Watabe)<BR>
* </P>
* @author HLC H.watabe
*/
public class FindSocietyDataDAO extends AbstractSimpleRdbDao {

    /** データ検索条件 */
    private FindSocietyDataCondition _cond;

    /**
     * デフォルトコンストラクタ
     */
    public FindSocietyDataDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを返します
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{
                Tbj02EigyoDaicho.DAICHONO
                ,RepaVbjaMea10Irsk.IRSKCD
                ,RepaVbjaMea10Irsk.IRSKSUBCD
                ,RepaVbjaMea11DisplayIrsk.DSIKKBNCD
                ,RepaVbjaMea12DisplayGyomKbn.GYOMKBNCD
        };
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {
        return getSocietyData();
    }

    /**
     * 営業作業台帳のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSocietyData() {

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
        sql.append(" " +Tbj02EigyoDaicho.TBNAME + ", ");
        sql.append(" " + RepaVbjaMea10Irsk.TBNAME + ", ");
        sql.append(" " + RepaVbjaMea11DisplayIrsk.TBNAME +", ");
        sql.append(" " + RepaVbjaMea12DisplayGyomKbn.TBNAME + ", ");
        sql.append(" " + RepaVbjaMeu29Cc.TBNAME+ ", ");
        sql.append(" " + RepaVbjaMeu07SikKrSprd.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMea10Irsk.ALASUSEFLG + " = '1'");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.REQUESTDESTINATION + " = " + RepaVbjaMea10Irsk.IRSKALASHYOJIKJ + "(+)" );
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea10Irsk.IRSKCD + " = " + RepaVbjaMea11DisplayIrsk.IRSKCD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea10Irsk.IRSKSUBCD + " = " + RepaVbjaMea11DisplayIrsk.IRSKSUBCD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea11DisplayIrsk.JYUCTYPE + " = " + RepaVbjaMea12DisplayGyomKbn.JYUCTYPE +"(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea11DisplayIrsk.IRSKCD + " = " + RepaVbjaMea12DisplayGyomKbn.IRSKCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea11DisplayIrsk.IRSKSUBCD + " = " + RepaVbjaMea12DisplayGyomKbn.IRSKSUBCD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea12DisplayGyomKbn.GYOMKBNCD + " = " + RepaVbjaMeu29Cc.KYCD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.DAICHONO + " ='" + _cond.getDaichoNo() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea10Irsk.IRSKCD + " = " + RepaVbjaMeu07SikKrSprd.SIKCD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea10Irsk.IRSKALASHYOJIKJ + " = '" + _cond.getRequestDestination() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea10Irsk.HKYMD + " <= '" + _cond.getKikanFrom() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea11DisplayIrsk.HKYMD + " <= '" + _cond.getKikanFrom() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea12DisplayGyomKbn.HKYMD + " <= '" + _cond.getKikanFrom() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu07SikKrSprd.STARTYMD + " <= '" + _cond.getKikanFrom() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea10Irsk.HAISYMD + " >= '" + _cond.getKikanTo() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea11DisplayIrsk.HAISYMD + " >= '" + _cond.getKikanTo() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea12DisplayGyomKbn.HAISYMD + " >= '" + _cond.getKikanTo() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu07SikKrSprd.ENDYMD + " >= '" + _cond.getKikanTo() + "' ");

        sql.append(" UNION ALL ");
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
        sql.append(" " +Tbj02EigyoDaicho.TBNAME + ", ");
        sql.append(" " + RepaVbjaMea10Irsk.TBNAME + ", ");
        sql.append(" " + RepaVbjaMea11DisplayIrsk.TBNAME +", ");
        sql.append(" " + RepaVbjaMea12DisplayGyomKbn.TBNAME + ", ");
        sql.append(" " + RepaVbjaMeu29Cc.TBNAME+ ", ");
        sql.append(" " + RepaVbjaMeu07SikKrSprd.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMea10Irsk.ALASUSEFLG + " <> '1'");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.REQUESTDESTINATION + " = " + RepaVbjaMeu07SikKrSprd.HYOJIKJ + "(+)" );
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea10Irsk.IRSKCD + " = " + RepaVbjaMea11DisplayIrsk.IRSKCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea10Irsk.IRSKSUBCD + " = " + RepaVbjaMea11DisplayIrsk.IRSKSUBCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea11DisplayIrsk.JYUCTYPE + " = " + RepaVbjaMea12DisplayGyomKbn.JYUCTYPE + "(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea11DisplayIrsk.IRSKCD + " = " + RepaVbjaMea12DisplayGyomKbn.IRSKCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea11DisplayIrsk.IRSKSUBCD + " = " + RepaVbjaMea12DisplayGyomKbn.IRSKSUBCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea12DisplayGyomKbn.GYOMKBNCD + " = " + RepaVbjaMeu29Cc.KYCD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.DAICHONO + " ='" + _cond.getDaichoNo() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu07SikKrSprd.SIKCD + " = " + RepaVbjaMea10Irsk.IRSKCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu07SikKrSprd.HYOJIKJ + " = '" + _cond.getRequestDestination() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea10Irsk.HKYMD + " <= '" + _cond.getKikanFrom() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea11DisplayIrsk.HKYMD + " <= '" + _cond.getKikanFrom() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea12DisplayGyomKbn.HKYMD + " <= '" + _cond.getKikanFrom() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu07SikKrSprd.STARTYMD + " <= '" + _cond.getKikanFrom() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea10Irsk.HAISYMD + " >= '" + _cond.getKikanTo() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea11DisplayIrsk.HAISYMD + " >= '" + _cond.getKikanTo() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMea12DisplayGyomKbn.HAISYMD + " >= '" + _cond.getKikanTo() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu07SikKrSprd.ENDYMD + " >= '" + _cond.getKikanTo() + "' ");

        return sql.toString();
    }

    /**
     * 営業作業台帳の検索を行います
     *
     * @return キャンペーン一覧VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<FindSocietyDataVO> findSocietyData(FindSocietyDataCondition cond) throws HAMException {

        super.setModel(new FindSocietyDataVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
