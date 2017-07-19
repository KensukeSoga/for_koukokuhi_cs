package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.integ.util.ECPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * チェックリスト関連の業務会計DB用DAO
 * @author
 *
 */
public class CheckListECDAO extends AbstractRdbDao {

    /** 検索条件 */
    private FindCheckListTantoCondition _findCheckListTantoCondition = null;
    private GetRepDataForChkListCondition _getRepDataForChkListCondition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode {
        LIST, REPDATA, KYK,
    };

    private SelSqlMode _SelSqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public CheckListECDAO() {
        super.setPoolConnectClass(ECPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL() {
        String sql = "";

        if (SelSqlMode.LIST.equals(_SelSqlMode)) {
            sql = getSelectSQLForLIST();
        } else if (SelSqlMode.REPDATA.equals(_SelSqlMode)) {
            sql = getSelectSQLForREPDATA();
        } else if (SelSqlMode.KYK.equals(_SelSqlMode)) {
            sql = getSelectSQLForKYK();
        }

        return sql.toString();
    };


    /**
     * モード"LIST"のSQL文を返します
     */
    public String getSelectSQLForKYK() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
//        sql.append("     " + "MEU07_SIKCDKYK"   + " AS SIKCDKYK ");
//        sql.append("    ," + "MEU07_KYKHYOJIKJ" + " AS KYOKUNM ");
        sql.append("     " + "JYUCHUM.IRAISSIKCD"   + " AS IRAISSIKCD ");
        sql.append(" FROM ");
        sql.append("     " + "JYUCHU" + " ");
        sql.append("    ," + "JYUCHUM" + " ");
//        sql.append("    ," + "MEU07SIKKRSPRD" + " ");
        sql.append(" WHERE ");
        sql.append("     " + "JYUCHU.ATEGSYOCD   = '" + _findCheckListTantoCondition.getEgsCd() + "'" + " ");
        sql.append(" AND ( ");
        for (int i = 0; i < _findCheckListTantoCondition.getTokuisakiCdList().length; i++) {
            if (i > 0) {
                sql.append(" OR ");
            }
            sql.append(" " + "JYUCHU.TKSKGYCD     = '" + _findCheckListTantoCondition.getTokuisakiCdList()[i] + "' " + " ");
        }
        sql.append(" ) ");
        sql.append(" AND " + "JYUCHUM.JYUTNO     = JYUCHU.JYUTNO" + " ");
        sql.append(" AND " + "JYUCHUM.TKSKGYCD   = JYUCHU.TKSKGYCD " + " ");
        sql.append(" AND " + "JYUCHUM.ATEGSYOCD  = JYUCHU.ATEGSYOCD " + " ");
        sql.append(" AND " + "JYUCHUM.STPKBN    <> '1' " + " ");
        sql.append(" AND ( ");
        sql.append("     " + "JYUCHUM.KJOYOTYMD BETWEEN '" + DateUtil.toString(_findCheckListTantoCondition.getFromDate()) + "' AND '" + DateUtil.toString(_findCheckListTantoCondition.getToDate()) + "' " + " ");
        sql.append(" OR  " + "JYUCHUM.KEISYMD   BETWEEN '" + DateUtil.toString(_findCheckListTantoCondition.getFromDate()) + "' AND '" + DateUtil.toString(_findCheckListTantoCondition.getToDate()) + "' " + " ");
        sql.append(" ) ");
//        sql.append(" AND " + "MEU07_SIKCD        = JYUCHUM.IRAISSIKCD " + " ");
//        sql.append(" AND " + "MEU07_STARTYMD    <= '" + DateUtil.toString(_findCheckListTantoCondition.getToDate()) + "' " + " ");
//        sql.append(" AND " + "MEU07_ENDYMD      >= '" + DateUtil.toString(_findCheckListTantoCondition.getToDate()) + "' " + " ");
//        sql.append(" GROUP BY ");
//        sql.append("     " + "MEU07_SIKCDKYK"   + " ");
//        sql.append("    ," + "MEU07_KYKHYOJIKJ" + " ");

        return sql.toString();
    };

    /**
     * モード"LIST"のSQL文を返します
     */
    public String getSelectSQLForLIST() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append("     " + "JYUCHU.EGTNTCD" + " ");
        sql.append("    ," + "JYUCHUM.IRAISSIKCD" + " ");
        sql.append(" FROM ");
        sql.append("     " + "JYUCHU" + " ");
        sql.append("    ," + "JYUCHUM" + " ");
//        sql.append("    ," + "MEU07SIKKRSPRD" + " ");
        sql.append(" WHERE ");
        sql.append("     " + "JYUCHU.ATEGSYOCD   = '" + _findCheckListTantoCondition.getEgsCd() + "'" + " ");
        sql.append(" AND ( ");
        for (int i = 0; i < _findCheckListTantoCondition.getTokuisakiCdList().length; i++) {
            if (i > 0) {
                sql.append(" OR ");
            }
            sql.append(" ( ");
            String[] tokuiCd = _findCheckListTantoCondition.getTokuisakiCdList()[i].split("-");
            sql.append(" " + "JYUCHU.TKSKGYCD     = '" + tokuiCd[0] + "' " + " ");
            sql.append(" AND  ");
            sql.append(" " + "JYUCHU.TKSBMNSEQNO  = '" + tokuiCd[1] + "' " + " ");
            sql.append(" ) ");
        }
        sql.append(" ) ");
        sql.append(" AND " + "JYUCHUM.JYUTNO     = JYUCHU.JYUTNO" + " ");
        sql.append(" AND " + "JYUCHUM.TKSKGYCD   = JYUCHU.TKSKGYCD " + " ");
        sql.append(" AND " + "JYUCHUM.ATEGSYOCD  = JYUCHU.ATEGSYOCD " + " ");
        sql.append(" AND " + "JYUCHUM.STPKBN    <> '1' " + " ");
        sql.append(" AND ( ");
        sql.append("     " + "JYUCHUM.KJOYOTYMD BETWEEN '" + DateUtil.toString(_findCheckListTantoCondition.getFromDate()) + "' AND '" + DateUtil.toString(_findCheckListTantoCondition.getToDate()) + "' " + " ");
        sql.append(" OR  " + "JYUCHUM.KEISYMD   BETWEEN '" + DateUtil.toString(_findCheckListTantoCondition.getFromDate()) + "' AND '" + DateUtil.toString(_findCheckListTantoCondition.getToDate()) + "' " + " ");
        sql.append(" ) ");
//        sql.append(" AND " + "MEU07_SIKCD        = JYUCHUM.IRAISSIKCD " + " ");
//        sql.append(" AND " + "MEU07_STARTYMD    <= '" + DateUtil.toString(_findCheckListTantoCondition.getToDate()) + "' " + " ");
//        sql.append(" AND " + "MEU07_ENDYMD      >= '" + DateUtil.toString(_findCheckListTantoCondition.getToDate()) + "' " + " ");

//        if (_findCheckListTantoCondition.getKyokuCdList() != null && _findCheckListTantoCondition.getKyokuCdList().length > 0) {
//            sql.append(" AND ( ");
//            for (int i = 0; i < _findCheckListTantoCondition.getKyokuCdList().length; i++) {
//                if (i > 0) {
//                    sql.append(" OR ");
//                }
//                sql.append(" " + "MEU07_SIKCDKYK     = '" + _findCheckListTantoCondition.getKyokuCdList()[i] + "' " + " ");
//            }
//            sql.append(" ) ");
//        }
        sql.append(" GROUP BY ");
        sql.append("     " + "JYUCHU.EGTNTCD" + " ");
        sql.append("    ," + "JYUCHUM.IRAISSIKCD" + " ");

        return sql.toString();
    };

    /**
     * モード"REPDATA"のSQL文を返します
     */
    public String getSelectSQLForREPDATA() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append("     " + "JYUCHU.TKSKGYCD"                 + " AS TKSKGYCD ");
        sql.append("    ," + "JYUCHU.TKSBMNSEQNO"              + " AS TKSBMNSEQNO ");
        sql.append("    ," + "JYUCHU.TKSTNTSEQNO"              + " AS TKSTNTSEQNO ");
//        sql.append("    ," + "MEU2FHMOK.MEU2F_NAIYJ"           + " AS HMOKNM ");
        sql.append("    ," + "URIAGEM.HMOKCD"                  + " AS HMOKNM ");
        sql.append("    ," + "JYUCHUM.KKNAMEJ"                 + " AS KKNAMEJ ");
        //sql.append("    ," + "JYUCHUM.HOSOK"                   + " AS HOSOK ");
        sql.append("    ," + "JYUCHUMNSM.HSOKNAISY"            + " AS HOSOK ");
        sql.append("    ," + "JYUCHUM.TERMFRYY"                + " AS TERMFRYY ");
        sql.append("    ," + "JYUCHUM.TERMFRMM"                + " AS TERMFRMM ");
        sql.append("    ," + "JYUCHUM.TERMFRDD"                + " AS TERMFRDD ");
        sql.append("    ," + "JYUCHUM.TERMTOYY"                + " AS TERMTOYY ");
        sql.append("    ," + "JYUCHUM.TERMTOMM"                + " AS TERMTOMM ");
        sql.append("    ," + "JYUCHUM.TERMTODD"                + " AS TERMTODD ");
        sql.append("    ," + "JYUCHUM.KEISYMD"                 + " AS KEISYMD ");
        sql.append("    ," + "URIAGEM.TRGAK"                   + " AS TRGAK ");
        sql.append("    ," + "URIAGEM.NEBIGAK"                 + " AS NEBIGAK ");
//        sql.append("    ," + "MEH_SZEIKBN.NAIYJ"               + " AS KBNNM ");
        sql.append("    ," + "URIAGEM.SZEIKBN"                 + " AS KBNNM ");
//        sql.append("    ," + "MEU07SIKKRSPRD.MEU07_KYKHYOJIKJ" + " AS KYOKUNM ");
        sql.append("    ," + "JYUCHUM.IRAISSIKCD"              + " AS KYOKUNM ");
        sql.append("    ," + "JYUCHUM.JYUTNO"                  + " AS JYUTNO ");
        sql.append("    ," + "JYUCHUM.JYMEISEQ"                + " AS JYMEISEQ ");
        sql.append("    ," + "JYUCHU.EGTNTCD"                  + " AS EGTNTCD ");
        sql.append(" FROM ");
        sql.append("     " + "JYUCHU" + " ");
        sql.append("    ," + "JYUCHUM" + " ");
        sql.append("    ," + "URIAGEM" + " ");
        sql.append("    ," + "JYUCHUMNSM" + " ");
        sql.append(" WHERE ");
        //結合条件(受注明細)
        sql.append("     " + "JYUCHU.ATEGSYOCD"    + " = " + "JYUCHUM.ATEGSYOCD");
        sql.append(" AND " + "JYUCHU.TKSKGYCD"     + " = " + "JYUCHUM.TKSKGYCD");
        sql.append(" AND " + "JYUCHU.TKSBMNSEQNO"  + " = " + "JYUCHUM.TKSBMNSEQNO");
        sql.append(" AND " + "JYUCHU.TKSTNTSEQNO"  + " = " + "JYUCHUM.TKSTNTSEQNO");
        sql.append(" AND " + "JYUCHU.JYUTNO"       + " = " + "JYUCHUM.JYUTNO");
        sql.append(" AND " + "JYUCHUM.STPKBN"      + " <> " + "'1'");
        //結合条件(受注明細(正味))
        sql.append(" AND " + "JYUCHUM.ATEGSYOCD"    + " = " + "JYUCHUMNSM.ATEGSYOCD(+)");
        sql.append(" AND " + "JYUCHUM.TKSKGYCD"     + " = " + "JYUCHUMNSM.TKSKGYCD(+)");
        sql.append(" AND " + "JYUCHUM.TKSBMNSEQNO"  + " = " + "JYUCHUMNSM.TKSBMNSEQNO(+)");
        sql.append(" AND " + "JYUCHUM.TKSTNTSEQNO"  + " = " + "JYUCHUMNSM.TKSTNTSEQNO(+)");
        sql.append(" AND " + "JYUCHUM.JYUTNO"       + " = " + "JYUCHUMNSM.JYUTNO(+)");
        sql.append(" AND " + "JYUCHUM.JYMEISEQ"     + " = " + "JYUCHUMNSM.JYMEISEQ(+)");
        //結合条件(売上明細)
        sql.append(" AND " + "JYUCHUM.ATEGSYOCD"    + " = " + "URIAGEM.ATEGSYOCD");
        sql.append(" AND " + "JYUCHUM.TKSKGYCD"     + " = " + "URIAGEM.TKSKGYCD");
        sql.append(" AND " + "JYUCHUM.TKSBMNSEQNO"  + " = " + "URIAGEM.TKSBMNSEQNO");
        sql.append(" AND " + "JYUCHUM.TKSTNTSEQNO"  + " = " + "URIAGEM.TKSTNTSEQNO");
        sql.append(" AND " + "JYUCHUM.JYUTNO"       + " = " + "URIAGEM.JYUTNO");
        sql.append(" AND " + "JYUCHUM.JYMEISEQ"     + " = " + "URIAGEM.JYMEISEQ");
        sql.append(" AND " + "URIAGEM.STPKBN"       + " = " + "'0'");
//        //結合条件(費目)
//        sql.append(" AND " + "URIAGEM.HMOKCD"          + " = " + "MEU2FHMOK.MEU2F_HMOKCD");
//        sql.append(" AND " + "MEU2FHMOK.MEU2F_HAISYMD" + " = " + "'99999999'");
//        //結合条件(税区分)
//        sql.append(" AND " + "URIAGEM.SZEIKBN"         + " = " + "MEH_SZEIKBN.SZEIKBNCD");
//        sql.append(" AND " + "MEH_SZEIKBN.HAISYMD"     + " = " + "'99999999'");
//        //結合条件(組織～)
//        sql.append(" AND " + "JYUCHUM.IRAISSIKCD"            + "  = " + "MEU07SIKKRSPRD.MEU07_SIKCD");
//        sql.append(" AND " + "MEU07SIKKRSPRD.MEU07_STARTYMD" + " <= " + "'" + DateUtil.toString(_getRepDataForChkListCondition.getToDate()) + "'");
//        sql.append(" AND " + "MEU07SIKKRSPRD.MEU07_ENDYMD"   + " >= " + "'" + DateUtil.toString(_getRepDataForChkListCondition.getToDate()) + "'");

        //検索条件(得意先)
        sql.append(" AND " + "JYUCHU.ATEGSYOCD   = '" + _getRepDataForChkListCondition.getEgsCd() + "'" + " ");
        sql.append(" AND ( ");
        for (int i = 0; i < _getRepDataForChkListCondition.getTokuisakiCdList().length; i++) {
            if (i > 0) {
                sql.append(" OR ");
            }
            sql.append(" ( ");
            String[] tokuiCd = _getRepDataForChkListCondition.getTokuisakiCdList()[i].split("-");
            sql.append(" " + "JYUCHU.TKSKGYCD     = '" + tokuiCd[0] + "' " + " ");
            sql.append(" AND  ");
            sql.append(" " + "JYUCHU.TKSBMNSEQNO  = '" + tokuiCd[1] + "' " + " ");
            sql.append(" ) ");
        }
        sql.append(" ) ");
        //検索条件(担当者)
        if (_getRepDataForChkListCondition.getTntCdList() != null && _getRepDataForChkListCondition.getTntCdList().length > 0) {
            sql.append(" AND JYUCHU.EGTNTCD IN ( ");
            for (int i = 0; i < _getRepDataForChkListCondition.getTntCdList().length; i++) {
                if (i > 0) {
                    sql.append(" , ");
                }
                sql.append(" '" + _getRepDataForChkListCondition.getTntCdList()[i] + "' ");
            }
            sql.append(" ) ");
        }
        //検索条件(発注局)
        if (_getRepDataForChkListCondition.getKyokuCdList() != null && _getRepDataForChkListCondition.getKyokuCdList().length > 0) {
            sql.append(" AND JYUCHUM.IRAISSIKCD IN ( ");
            for (int i = 0; i < _getRepDataForChkListCondition.getKyokuCdList().length; i++) {
                if (i > 0) {
                    sql.append(" , ");
                }
                sql.append(" '" + _getRepDataForChkListCondition.getKyokuCdList()[i] + "' ");
            }
            sql.append(" ) ");
        }
        //検索条件(期間)
        sql.append(" AND ( ");
        sql.append("     " + "JYUCHUM.KJOYOTYMD BETWEEN '" + DateUtil.toString(_getRepDataForChkListCondition.getFromDate()) + "' AND '" + DateUtil.toString(_getRepDataForChkListCondition.getToDate()) + "' " + " ");
        sql.append(" OR  " + "JYUCHUM.KEISYMD   BETWEEN '" + DateUtil.toString(_getRepDataForChkListCondition.getFromDate()) + "' AND '" + DateUtil.toString(_getRepDataForChkListCondition.getToDate()) + "' " + " ");
        sql.append(" ) ");

        sql.append(" ORDER BY ");
        if (_getRepDataForChkListCondition.getOrderKbn() == 0) {
            sql.append("     " + "JYUCHUM.JYUTNO" + " ");
            sql.append("    ," + "JYUCHUM.JYMEISEQ" + " ");
        } else if (_getRepDataForChkListCondition.getOrderKbn() == 1) {
            sql.append("     " + "JYUCHU.EGTNTCD" + " ");
            sql.append("    ," + "JYUCHUM.JYUTNO" + " ");
            sql.append("    ," + "JYUCHUM.JYMEISEQ" + " ");
        }

        return sql.toString();
    };

    /**
     * 画面で指定した条件で検索を行い、一覧に表示するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindCheckListHattyuKykVO> findCheckListHattyuKyk(FindCheckListTantoCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindCheckListHattyuKykVO());
        try {
            _SelSqlMode = SelSqlMode.KYK;
            _findCheckListTantoCondition = cond;
            return (List<FindCheckListHattyuKykVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 画面で指定した条件で検索を行い、一覧に表示するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindCheckListTantoVO> findCheckListListData(FindCheckListTantoCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindCheckListTantoVO());
        try {
            _SelSqlMode = SelSqlMode.LIST;
            _findCheckListTantoCondition = cond;
            return (List<FindCheckListTantoVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 画面で指定した条件で検索を行い、帳票に出力するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepDataForChkListR3VO> findCheckListREPDATA(GetRepDataForChkListCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new RepDataForChkListR3VO());
        try {
            _SelSqlMode = SelSqlMode.REPDATA;
            _getRepDataForChkListCondition = cond;
            return (List<RepDataForChkListR3VO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
