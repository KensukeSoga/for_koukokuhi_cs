package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj13CarOutCtrl;
import jp.co.isid.ham.integ.tbl.Mbj14MediaOutCtrl;
import jp.co.isid.ham.integ.tbl.Tbj01MediaPlan;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* 媒体コストの情報取得DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/4/2 HLC H.Watabe)<BR>
* </P>
*
* @author HLC H.watabe
*/
public class FindMediaCostDAO extends AbstractSimpleRdbDao {

    /** データ検索条件 */
    private FindCostManagementReportCondition _cond;

    /**
     * デフォルトコンストラクタ
     */
    public FindMediaCostDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * テーブル列名を取得
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{
                "SUM(" + Tbj02EigyoDaicho.GROSS + ") AS SUMGROSS"
                ,"SUM(" + Tbj02EigyoDaicho.HMCOST + ") AS SUMHMCOST"
                ,Tbj02EigyoDaicho.DCARCD
                ,Mbj05Car.CARNM
                ,Tbj02EigyoDaicho.MEDIACD
                ,Mbj03Media.MEDIANM
                ,"TRUNC(" + Tbj02EigyoDaicho.SEIKYUYM + ", 'MM') AS TBJ02_SEIKYUYM"
        };
    }

    /**
     * テーブル名取得
     */
    @Override
    public String getTableName() {
        return Tbj02EigyoDaicho.TBNAME;
    }

    /**
     * 更新日付フィールド取得
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

        return getCreateCost();
    }

    /**
     * 媒体コストデータ取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getCreateCost()
    {
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
        sql.append(" " + getTableName() + ", ");
        sql.append(" " + Tbj01MediaPlan.TBNAME + ", ");
        sql.append(" " + Mbj05Car.TBNAME + ", ");
        sql.append(" " + Mbj13CarOutCtrl.TBNAME + ", ");
        sql.append(" " + Mbj03Media.TBNAME + ", ");
        sql.append(" " + Mbj14MediaOutCtrl.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj02EigyoDaicho.SEIKYUYM + " >= TO_DATE('" + _cond.getKikanFrom() + "','YYYY/MM') ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.SEIKYUYM + " < TO_DATE('" + _cond.getKikanTo() + "','YYYY/MM') ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAPLANNO + " = " + Tbj01MediaPlan.MEDIAPLANNO + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.DCARCD + " = " + Mbj05Car.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.DCARCD + " = " + Mbj13CarOutCtrl.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIACD + " = " + Mbj03Media.MEDIACD + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIACD + " = " + Mbj14MediaOutCtrl.MEDIACD + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.REPORTCD + " = 'R05' ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.OUTPUTFLG + " = '1' ");
        sql.append(" AND ");
        sql.append(" " + Mbj14MediaOutCtrl.REPORTCD + " = 'R05' ");
        sql.append(" AND ");
        sql.append(" " + Mbj14MediaOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj14MediaOutCtrl.OUTPUTFLG + " = '1' ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.GROSS + "<> 0 ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.HMCOST + "<> 0 ");
        sql.append(" GROUP BY ");
        sql.append(" " + Tbj02EigyoDaicho.DCARCD + ", ");
        sql.append(" " + Mbj05Car.CARNM + ", ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIACD + ", ");
        sql.append(" " + Mbj03Media.MEDIANM + ", ");
        sql.append(" TRUNC(" + Tbj02EigyoDaicho.SEIKYUYM + ",'MM'), ");
        sql.append(" " + Mbj13CarOutCtrl.SORTNO + ", ");
        sql.append(" " + Mbj14MediaOutCtrl.SORTNO + " ");
        sql.append(" ORDER BY ");
        sql.append(" TO_CHAR(" + Tbj02EigyoDaicho.SEIKYUYM + ",'YYYY/MM'), ");
        sql.append(" " + Mbj13CarOutCtrl.SORTNO + ", ");
        sql.append(" " + Mbj14MediaOutCtrl.SORTNO + " ");


        return sql.toString();
    }


    /**
     * 媒体コスト取得
     * @return 媒体コストVOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<FindMediaCostVO> findMediaCost(
            FindCostManagementReportCondition cond) throws HAMException {

        super.setModel(new FindMediaCostVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
