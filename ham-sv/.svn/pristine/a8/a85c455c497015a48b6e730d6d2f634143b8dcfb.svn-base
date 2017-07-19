package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj04Keiretsu;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj01MediaPlan;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
*
* <P>
* 営業作業台帳帳票の情報取得DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/3/26 HLC M.Tsuchiya)<BR>
* </P>
*
* @author HLC M.Tsuchiya
*/

public class FindAuthorityAccountbookReportDAO extends AbstractRdbDao {

    /** データ検索条件 */
    private FindAccountBookOutPutDataCondition _cond;

    /**
     * デフォルトコンストラクタ
     */
    public FindAuthorityAccountbookReportDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }


    /**
     * プライマリキーを返します
     *
     * @return String[] プライマリキー
     */
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        // new String[] {};
        return null;
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj02EigyoDaicho.TBNAME;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[]{
                Tbj01MediaPlan.CAMPCD
                ,Tbj02EigyoDaicho.MEDIAPLANNO
                ,Tbj02EigyoDaicho.DAICHONO
                ,Tbj02EigyoDaicho.SEIKYUYM
                ,Tbj02EigyoDaicho.MEDIACD
                ,Tbj02EigyoDaicho.MEDIASCD
                ,Tbj02EigyoDaicho.MEDIASNM
                ,Mbj04Keiretsu.KEIRETSUSNM
                ,Tbj02EigyoDaicho.DCARCD
                ,Tbj02EigyoDaicho.HIYOUNO
                ,Tbj02EigyoDaicho.CAMPAIGN
                ,Tbj02EigyoDaicho.NAIYOHIMOKU
                ,Tbj02EigyoDaicho.KIKANFROM
                ,Tbj02EigyoDaicho.KIKANTO
                ,Tbj02EigyoDaicho.GROSS
                ,Mbj03Media.DNEBIKI
                ,Tbj02EigyoDaicho.DNEBIKIGAKU
                ,Tbj02EigyoDaicho.HMCOST
                ,Tbj02EigyoDaicho.APLRIEKIRITSU
                ,Tbj02EigyoDaicho.APLRIEKIGAKU
                ,Tbj02EigyoDaicho.MEDIAHARAI
                ,Tbj02EigyoDaicho.MEDIAMARGINRITSU
                ,Tbj02EigyoDaicho.MEDIAMARGINGAKU
                ,Tbj02EigyoDaicho.MEDIAGENKA
                ,Tbj02EigyoDaicho.TORIRIEKI
                ,Tbj02EigyoDaicho.RIEKIHAIBUN
                ,Tbj02EigyoDaicho.NAIKINRIEKI
                ,Tbj02EigyoDaicho.FURIKAERIEKI
                ,Tbj02EigyoDaicho.EIGYOYOIN
                ,Tbj02EigyoDaicho.BIKO
                ,Tbj02EigyoDaicho.SEIKYUFLG
                ,Tbj02EigyoDaicho.CPDATE
                ,Tbj02EigyoDaicho.CRTDATE
                ,Tbj02EigyoDaicho.CRTNM
                ,Tbj02EigyoDaicho.CRTAPL
                ,Tbj02EigyoDaicho.CRTID
                ,Tbj02EigyoDaicho.UPDDATE
                ,Tbj02EigyoDaicho.UPDNM
                ,Tbj02EigyoDaicho.UPDAPL
                ,Tbj02EigyoDaicho.UPDID
                ,Mbj03Media.MEDIANM
                ,Mbj05Car.CARNM
                ,Tbj01MediaPlan.PHASE
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        return getAuthorityAccountBook();
    }

    /**
     * 営業作業台帳のSQL文を返します
     *
     * @return String SQL文
     */
    private String getAuthorityAccountBook() {

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
        sql.append(" "+ getTableName() + ", ");
        sql.append(" Tbj01MediaPlan, ");
        sql.append(" Mbj03Media, ");
        sql.append(" Mbj04Keiretsu, ");
        sql.append(" Mbj05Car ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAPLANNO + " = " + Tbj01MediaPlan.MEDIAPLANNO + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIACD + " = " + Mbj03Media.MEDIACD + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.DCARCD + " = " + Mbj05Car.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.KEIRETSUCD + " = " + Mbj04Keiretsu.KEIRETSUCD + " ");

        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.SEIKYUYM + " >= TO_DATE('" + _cond.getKikanfrom() + "', 'YYYY/MM/DD') ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.SEIKYUYM + " <= TO_DATE('" + _cond.getKikanto() + "', 'YYYY/MM/DD') ");

        if (!_cond.getMediacd().isEmpty()) {
            sql.append(" AND ");
            sql.append(" " + Tbj02EigyoDaicho.MEDIACD + " IN (" + _cond.getMediacd() + ") ");
        }
        if (!_cond.getSeikyuflg()) {
            sql.append(" AND ");
            sql.append(" " + Tbj02EigyoDaicho.SEIKYUFLG + "= '0'");
        }
        if (_cond.getCarList() != null && _cond.getCarList().size() > 0) {
            sql.append(" AND ");
            sql.append(" " + Tbj02EigyoDaicho.DCARCD + " IN ('" + StringUtil.join("','", _cond.getCarList().toArray(new String[0])) + "') ");
        }
        sql.append(" ORDER BY ");
//        sql.append(" " + Tbj02EigyoDaicho.DCARCD + ", ");
//        sql.append(" " + Tbj02EigyoDaicho.SEIKYUYM + ", ");
//        sql.append(" " + Tbj02EigyoDaicho.MEDIAPLANNO+ " ");
        sql.append(" " + Mbj05Car.SORTNO + ", ");
        sql.append(" " + Mbj03Media.SORTNO + ", ");
        sql.append(" " + Tbj02EigyoDaicho.KIKANFROM+ ", ");
        sql.append(" " + Tbj02EigyoDaicho.KIKANTO+ ", ");
        sql.append(" " + Tbj02EigyoDaicho.DAICHONO+ " ");

        return sql.toString();
    }

    /**
     * 営業作業台帳帳票の検索を行います
     *
     * @return 営業作業台帳帳票VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<FindAuthorityAccountBookReportVO> findAuthorityAccountBookReportByCond(FindAccountBookOutPutDataCondition cond) throws HAMException {

        super.setModel(new FindAuthorityAccountBookReportVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
