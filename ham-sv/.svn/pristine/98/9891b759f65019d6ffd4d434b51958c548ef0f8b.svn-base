package jp.co.isid.ham.common.model;

import java.text.SimpleDateFormat;
import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj01MediaPlan;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 媒体状況管理DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj01MediaPlanDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj01MediaPlanCondition _condition;
    private enum SqlMode{ALL,MAX,BYCOND,BYCAMPCD,CARSUMMONEY,BYMEDIACD,GETMEDIAPLANNO,BYCAMPCDSUM,BYCAMPCDANDMONTH,BYMEDIAPLANNO,BYCAMPCDDIST};
    private SqlMode _sqlMode = SqlMode.MAX;
    private Tbj13CampDetailVO _vo;
    private String _campCd;
    private String _kikanFrom;
    private String _kikanTo;


    /**
     * デフォルトコンストラクタ
     */
    public Tbj01MediaPlanDAO() {
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
                Tbj01MediaPlan.CAMPCD
                ,Tbj01MediaPlan.MEDIAPLANNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj01MediaPlan.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj01MediaPlan.CRTDATE
                ,Tbj01MediaPlan.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj01MediaPlan.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj01MediaPlan.CAMPCD
                ,Tbj01MediaPlan.MEDIAPLANNO
                ,Tbj01MediaPlan.YOTEIYM
                ,Tbj01MediaPlan.KEIRESTUCD
                ,Tbj01MediaPlan.DCARCD
                ,Tbj01MediaPlan.MEDIACD
                ,Tbj01MediaPlan.HIYOUNO
                ,Tbj01MediaPlan.AGENCY
                ,Tbj01MediaPlan.KENMEI
                ,Tbj01MediaPlan.MEMO
                ,Tbj01MediaPlan.PHASE
                ,Tbj01MediaPlan.TERM
                ,Tbj01MediaPlan.KIKANFROM
                ,Tbj01MediaPlan.KIKANTO
                ,Tbj01MediaPlan.HMOK
                ,Tbj01MediaPlan.BUYEROK
                ,Tbj01MediaPlan.BUDGET
                ,Tbj01MediaPlan.BUDGETHM
                ,Tbj01MediaPlan.ACTUAL
                ,Tbj01MediaPlan.ACTUALHM
                ,Tbj01MediaPlan.ADJUSTMENT
                ,Tbj01MediaPlan.DIFAMT
                ,Tbj01MediaPlan.DIFAMTHM
                ,Tbj01MediaPlan.BUDGETUPDFLG
                ,Tbj01MediaPlan.CRTDATE
                ,Tbj01MediaPlan.CRTNM
                ,Tbj01MediaPlan.CRTAPL
                ,Tbj01MediaPlan.CRTID
                ,Tbj01MediaPlan.UPDDATE
                ,Tbj01MediaPlan.UPDNM
                ,Tbj01MediaPlan.UPDAPL
                ,Tbj01MediaPlan.UPDID
        };
    }
    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {
        String sql = null;
        if (_sqlMode.equals(SqlMode.ALL)) {
            sql = getAllMediaPlan();
        } else if (_sqlMode.equals(SqlMode.MAX)) {
            sql = getMaxMediaPlnaCd();
        } else if (_sqlMode.equals(SqlMode.BYCOND)) {
            sql = getMediaPlanByCond();
        } else if (_sqlMode.equals(SqlMode.BYCAMPCD)) {
            sql = getMediaPlanByCampCd();
        } else if (_sqlMode.equals(SqlMode.CARSUMMONEY)) {
            sql = getMediaPlanSumMoney();
        } else if (_sqlMode.equals(SqlMode.BYMEDIACD)) {
            sql = getMediaPlanByMediaCd();
        } else if (_sqlMode.equals(SqlMode.GETMEDIAPLANNO)) {
            sql = getMediaPlanNo();
        } else if (_sqlMode.equals(SqlMode.BYCAMPCDSUM)) {
            sql = getMediaPlanByCampCdSUM();
        } else if (_sqlMode.equals(SqlMode.BYCAMPCDANDMONTH)) {
            sql = getMediaPlanSUMByCampCdAndMonty();
        } else if (_sqlMode.equals(SqlMode.BYMEDIAPLANNO)) {
            sql = getMediaPlanSUMByMediaPlanNo();
        } else if (_sqlMode.equals(SqlMode.BYCAMPCDDIST)) {
            sql = getMediaPlanByCampCdDist();
        }
        return sql;
    }

    /**
     * 媒体状況管理データを全て取得
     * @return SQL文
     */
    private String getAllMediaPlan()
    {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj01MediaPlan.MEDIAPLANNO + " ");

        return sql.toString();
    }

    /**
     *媒体管理NoMax値取得
     *@return SQL文
     */
    private String getMaxMediaPlnaCd() {

        StringBuffer sql = new StringBuffer();
        sql.append("SELECT ");
        sql.append(" NVL(MAX(" + Tbj01MediaPlan.MEDIAPLANNO + "),0) AS " + Tbj01MediaPlan.MEDIAPLANNO);
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");

        return sql.toString();
    }

    /**
     * 媒体状況管理の検索を行いますByCond
     * @return SQL文
     */
    private String getMediaPlanByCond() {

        StringBuffer sql = new StringBuffer();
        SimpleDateFormat sdf1 = new SimpleDateFormat("yyyy/MM");

        sql.append("SELECT ");
        sql.append(" " + Tbj01MediaPlan.MEDIAPLANNO);
        sql.append("," + Tbj01MediaPlan.ACTUAL);
        sql.append("," + Tbj01MediaPlan.ACTUALHM);
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" TO_CHAR(" + Tbj01MediaPlan.YOTEIYM + ",'YYYY/MM') = '" + sdf1.format(_vo.getYOTEIYM()) + "' ");
        sql.append(" AND ");
        sql.append(" " + Tbj01MediaPlan.CAMPCD + " = '" + _vo.getCAMPCD() + "' ");
        sql.append(" AND ");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + " ='" + _vo.getMEDIACD() + "' ");

        return sql.toString();
    }

    /**
     * 媒体状況管理の検索を行いますByキャンペーンコード
     * @return SQL文
     */
    private String getMediaPlanByCampCd() {

        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        sql.append(" * ");
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj01MediaPlan.CAMPCD + " = '" + _campCd + "' ");
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + ", ");
        sql.append(" " + Tbj01MediaPlan.YOTEIYM + " ");

        return sql.toString();
    }

    /**
     * キャンペーンコードで検索をします
     * @return SQL文
     */
    private String getMediaPlanByCampCdDist() {

        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        sql.append(" " + Tbj01MediaPlan.CAMPCD + ",");
        sql.append(" " + Tbj01MediaPlan.YOTEIYM + ",");
        sql.append(" MIN(" + Tbj01MediaPlan.KIKANFROM + ") AS " + Tbj01MediaPlan.KIKANFROM + ", ");
        sql.append(" MAX(" + Tbj01MediaPlan.KIKANTO + ") AS " + Tbj01MediaPlan.KIKANTO + ", ");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + " ");
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj01MediaPlan.CAMPCD + " = '" + _campCd + "' ");
        sql.append(" GROUP BY ");
        sql.append(" " + Tbj01MediaPlan.CAMPCD + ",");
        sql.append(" " + Tbj01MediaPlan.YOTEIYM + ",");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + " ");
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + ", ");
        sql.append(" " + Tbj01MediaPlan.YOTEIYM + " ");

        return sql.toString();
    }

    /**
     * 媒体状況管理の車種合計金額を取得します
     * @return SQL文
     */
    private String getMediaPlanSumMoney() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + ",");
        sql.append(" TO_DATE(TO_CHAR(" + Tbj01MediaPlan.YOTEIYM + ",'YYYY/MM'),'YYYY/MM') AS " + Tbj01MediaPlan.YOTEIYM + ",");
        sql.append(" NVL(SUM(" + Tbj01MediaPlan.BUDGET + "),0) AS " + Tbj01MediaPlan.BUDGET + ",");
        sql.append(" NVL(SUM(" + Tbj01MediaPlan.BUDGETHM + "),0) AS " + Tbj01MediaPlan.BUDGETHM);

        sql.append(" FROM");
        sql.append(" " + getTableName());

        sql.append(" WHERE");
        sql.append(" " + Tbj01MediaPlan.PHASE + " = " + _condition.getPhase());
        sql.append(" AND");
        sql.append(" " + Tbj01MediaPlan.DCARCD + " = '" + _condition.getDcarcd() + "'");

        sql.append(" GROUP BY");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + ",");
        sql.append(" TO_CHAR(" + Tbj01MediaPlan.YOTEIYM + ",'YYYY/MM')");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj01MediaPlan.MEDIACD);

        return sql.toString();
    }

    /**
     * 媒体状況管理から媒体コードを条件に検索します
     * @return SQL文
     */
    private String getMediaPlanByMediaCd() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append(" " + getTableColumnNames()[i]);
            } else {
                sql.append(", " + getTableColumnNames()[i]);
            }
        }
        sql.append(" FROM");
        sql.append(" " + getTableName());
        sql.append(" WHERE");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + " = '" + _condition.getMediacd() + "'");
        sql.append(" AND");
        sql.append(" " + Tbj01MediaPlan.YOTEIYM + " >='" + _kikanFrom + "'");
        sql.append(" AND");
        sql.append(" " + Tbj01MediaPlan.YOTEIYM + " <='" + _kikanTo + "'");
        sql.append(" ORDER BY");
        sql.append(" " + Tbj01MediaPlan.MEDIAPLANNO);

        return sql.toString();
    }

    /**
     * 営業作業台帳の入力データから媒体状況管理NOを取得します
     * @return SQL文
     */
    private String getMediaPlanNo() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append(" " + getTableColumnNames()[i]);
            } else {
                sql.append(", " + getTableColumnNames()[i]);
            }
        }
        sql.append(" FROM");
        sql.append(" " + getTableName());
        sql.append(" WHERE");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + " = '" + _condition.getMediacd() + "'");
        sql.append(" AND");
        sql.append(" " + Tbj01MediaPlan.DCARCD + " = '" + _condition.getDcarcd() + "'");
        sql.append(" AND");
        sql.append(" " + Tbj01MediaPlan.PHASE + " = '" + _condition.getPhase() + "'");
        sql.append(" AND");
        sql.append(" " + Tbj01MediaPlan.TERM + " = '" + _condition.getTerm() + "'");
        sql.append(" AND");
        sql.append(" " + Tbj01MediaPlan.KIKANFROM + " <=" + getDBModelInterface().ConvertToDBString(_condition.getKikanfrom()));
        sql.append(" AND");
        sql.append(" " + Tbj01MediaPlan.KIKANTO + " >=" + getDBModelInterface().ConvertToDBString(_condition.getKikanto()));
        sql.append(" ORDER BY");
        sql.append(" " + Tbj01MediaPlan.MEDIAPLANNO);

        return sql.toString();
    }

    /**
     * 媒体状況管理の検索を行いますByキャンペーンコード
     * @return SQL文
     */
    private String getMediaPlanByCampCdSUM() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" NVL(SUM(" + Tbj01MediaPlan.BUDGET + "),0) AS " + Tbj01MediaPlan.BUDGET + ",");
        sql.append(" NVL(SUM(" + Tbj01MediaPlan.BUDGETHM + "),0) AS " + Tbj01MediaPlan.BUDGETHM + ",");
        sql.append(" NVL(SUM(" + Tbj01MediaPlan.ACTUAL + "),0) AS " + Tbj01MediaPlan.ACTUAL + ",");
        sql.append(" NVL(SUM(" + Tbj01MediaPlan.ACTUALHM + "),0) AS " + Tbj01MediaPlan.ACTUALHM);

        sql.append(" FROM ");
        sql.append(" " + getTableName());

        sql.append(" WHERE");
        sql.append(" " + Tbj01MediaPlan.CAMPCD + " = '" + _campCd + "'");

        return sql.toString();
    }

    /**
     * 媒体状況管理の予定データをキャンペーンコードと予定月で検索
     * @return SQL文
     */
    private String getMediaPlanSUMByCampCdAndMonty() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" NVL(SUM(" + Tbj01MediaPlan.BUDGET + "),0) AS " + Tbj01MediaPlan.BUDGET + ",");
        sql.append(" NVL(SUM(" + Tbj01MediaPlan.BUDGETHM + "),0) AS " + Tbj01MediaPlan.BUDGETHM);

        sql.append(" FROM");
        sql.append(" " + getTableName());

        sql.append(" WHERE");
        sql.append(" " + Tbj01MediaPlan.CAMPCD + " = '" + _condition.getCampcd() + "'");
        sql.append(" AND");
        sql.append(" " + Tbj01MediaPlan.YOTEIYM + " = " + getDBModelInterface().ConvertToDBString(_condition.getYoteiym()));
        sql.append(" AND");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + " = '" + _condition.getMediacd() + "'");

        return sql.toString();
    }

    /**
     * 媒体状況管理Noで検索
     * @return SQL文
     */
    private String getMediaPlanSUMByMediaPlanNo() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append(" " + getTableColumnNames()[i]);
            } else {
                sql.append(", " + getTableColumnNames()[i]);
            }
        }

        sql.append(" FROM");
        sql.append(" " + getTableName());

        sql.append(" WHERE");
        sql.append(" " + Tbj01MediaPlan.MEDIAPLANNO + " = " + _condition.getMediaplanno());

        return sql.toString();
    }

    /**
     * 媒体状況管理テーブルを全て取得
     * @param なし
     * @return 媒体管理VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj01MediaPlanVO> findAllMediaPlan() throws HAMException {

        super.setModel(new Tbj01MediaPlanVO());

        try {
            _sqlMode = SqlMode.ALL;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 媒体状況管理テーブルの媒体管理Noの最大値を取得する.
     * @param なし
     * @return 媒体管理VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj01MediaPlanVO> findMediaPlanMaxCd() throws HAMException {

        super.setModel(new Tbj01MediaPlanVO());

        try {
            _sqlMode = SqlMode.MAX;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 媒体状況管理テーブルの検索ByCond
     * @param なし
     * @return 媒体管理VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj01MediaPlanVO> findMediaPlanByCond(Tbj13CampDetailVO vo) throws HAMException {

        super.setModel(new Tbj01MediaPlanVO());

        try {
            _vo = vo;
            _sqlMode = SqlMode.BYCOND;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     *車種合計金額の検索Byキャンペーンコードd
     * @param なし
     * @return 媒体管理VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj01MediaPlanVO> findMediaPlanSumMoney(Tbj01MediaPlanCondition cond) throws HAMException {

        super.setModel(new Tbj01MediaPlanVO());

        try {
            _sqlMode = SqlMode.CARSUMMONEY;
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 媒体状況管理のレコードを媒体コードで取得
     * @param cond 検索条件
     * @return 媒体状況管理VOリスト
     * @throws HAMException
     *              データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj01MediaPlanVO> findMediaPlanByMediaCd(Tbj01MediaPlanCondition cond,String kikanFrom,String kikanTo) throws HAMException {

        super.setModel(new Tbj01MediaPlanVO());

        try {
            _sqlMode = SqlMode.BYMEDIACD;
            _kikanFrom = kikanFrom;
            _kikanTo = kikanTo;
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 営業作業台帳のデータから媒体状況管理データを検索
     * @param cond 検索条件
     * @return 媒体状況管理VOリスト
     * @throws HAMException
     *              データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj01MediaPlanVO> findMediaPlanNo(Tbj01MediaPlanCondition cond) throws HAMException {

        super.setModel(new Tbj01MediaPlanVO());

        try {
            _sqlMode = SqlMode.GETMEDIAPLANNO;
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * キャンペーンCdを持つデータの合計金額を取得
     * @param キャンペーンCd
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj01MediaPlanVO> findMediaPlanByCampCdSUM(String CampCd) throws HAMException {

        super.setModel(new Tbj01MediaPlanVO());

        try {
            _sqlMode = SqlMode.BYCAMPCDSUM;
            _campCd = CampCd;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * キャンペーンCdの月単位で合計金額を取得
     * @param キャンペーンCd
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj01MediaPlanVO> findMediaPlanSUMByCdAndMonth(Tbj01MediaPlanCondition cond) throws HAMException {

        super.setModel(new Tbj01MediaPlanVO());

        try {
            _sqlMode = SqlMode.BYCAMPCDANDMONTH;
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 媒体状況管理NOで検索を行う
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj01MediaPlanVO> findMediaPlanByMediaPlanNo(Tbj01MediaPlanCondition cond) throws HAMException {

        super.setModel(new Tbj01MediaPlanVO());

        try {
            _sqlMode = SqlMode.BYMEDIAPLANNO;
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * キャンペーンコードで検索を行う
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj01MediaPlanVO> findMediaPlanByCampCd(String CampCd) throws HAMException {

        super.setModel(new Tbj01MediaPlanVO());

        try {
            _sqlMode = SqlMode.BYCAMPCD;
            _campCd = CampCd;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * キャンペーンコードで検索を行う
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj01MediaPlanVO> findMediaPlanByCampCdDist(String CampCd) throws HAMException {

        super.setModel(new Tbj01MediaPlanVO());

        try {
            _sqlMode = SqlMode.BYCAMPCDDIST;
            _campCd = CampCd;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
