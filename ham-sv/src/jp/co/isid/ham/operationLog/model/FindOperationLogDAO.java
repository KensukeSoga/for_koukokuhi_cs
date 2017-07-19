package jp.co.isid.ham.operationLog.model;

import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj28WorkLog;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 *
 * <P>
 * 稼働ログ取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/05/15 T.Kobayashi)<BR>
 * </P>
 *
 * @author T.Kobayashi
 */
public class FindOperationLogDAO extends AbstractRdbDao {

    /** データ検索条件 */
    private FindOperationLogCondition _cond = null;
    /** フラグON */
    private static final String FLG_ON = "1";
    /** 組織結合用文字列 */
    private static final String COMBINE_SOSHIKI = " || ' ' || ";

    /** 対象期間インデックス */
    private static final int IDX_CRTDATE = 0;
    /** ESQIDインデックス */
    private static final int IDX_HAMID = 1;
    /** 担当者名インデックス */
    private static final int IDX_HAMNM = 2;
    /** 組織名インデックス */
    private static final int IDX_SOSHIKI_FULLNM = 3;
    /** 画面名インデックス */
    private static final int IDX_FORMNM = 4;
    /** 機能名インデックス */
    private static final int IDX_KNONM = 5;
    /** 操作名インデックス */
    private static final int IDX_DSMNM = 6;

    /**
     * デフォルトコンストラクタ
     */
    public FindOperationLogDAO() {
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
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String[] getTableColumnNames() {

        String[] retTbl = new String[]{};

        if (_cond.getTotalFlg().indexOf(FLG_ON) == -1) {
            // 集計フラグが設定されていない場合

            retTbl = new String[]{
                    Tbj28WorkLog.CRTDATE,
                    Tbj28WorkLog.HAMID,
                    Tbj28WorkLog.HAMNM,
                    Tbj28WorkLog.SIKCDHONB,
                    Tbj28WorkLog.SIKNMHONB,
                    Tbj28WorkLog.SIKCDKYK,
                    Tbj28WorkLog.SIKNMKYK,
                    Tbj28WorkLog.SIKCDSITU,
                    Tbj28WorkLog.SIKNMSITU,
                    Tbj28WorkLog.SIKCDBU,
                    Tbj28WorkLog.SIKNMBU,
                    Tbj28WorkLog.SIKCDKA,
                    Tbj28WorkLog.SIKNMKA,
                    Tbj28WorkLog.FORMID,
                    Tbj28WorkLog.FORMNM,
                    Tbj28WorkLog.KNOID,
                    Tbj28WorkLog.KNONM,
                    Tbj28WorkLog.DSMID,
                    Tbj28WorkLog.DSMNM,
                    Tbj28WorkLog.SIKNMKYK + COMBINE_SOSHIKI +
                    Tbj28WorkLog.SIKNMSITU + COMBINE_SOSHIKI +
                    Tbj28WorkLog.SIKNMBU + COMBINE_SOSHIKI +
                    Tbj28WorkLog.SIKNMKA + COMBINE_SOSHIKI + " '' AS SOSHIKI_FULLNM",
                    "1 AS LOG_COUNT"
            };
        } else {
            // 集計フラグが設定されている場合

            String[] flgList = _cond.getTotalFlg().split(",");
            ArrayList<String> tblList = new ArrayList<String>();

            for (int i = 0; i < flgList.length; i++) {
                if (flgList[i].equals(FLG_ON)) {
                    if (i == IDX_CRTDATE) {
                        // 対象期間
                        tblList.add("TO_CHAR(" + Tbj28WorkLog.CRTDATE + ", 'YYYY/MM/DD') AS " + Tbj28WorkLog.CRTDATE);
                    } else if (i == IDX_HAMID) {
                        // ESQID
                        tblList.add(Tbj28WorkLog.HAMID);
                    } else if (i == IDX_HAMNM) {
                        // 担当者名
                        tblList.add(Tbj28WorkLog.HAMNM);
                    } else if (i == IDX_SOSHIKI_FULLNM) {
                        // 組織名
                        tblList.add(
                                Tbj28WorkLog.SIKNMKYK + COMBINE_SOSHIKI +
                                Tbj28WorkLog.SIKNMSITU + COMBINE_SOSHIKI +
                                Tbj28WorkLog.SIKNMBU + COMBINE_SOSHIKI +
                                Tbj28WorkLog.SIKNMKA + " AS SOSHIKI_FULLNM"
                                );
                    } else if (i == IDX_FORMNM) {
                        // 画面名
                        tblList.add(Tbj28WorkLog.FORMNM);
                    } else if (i == IDX_KNONM) {
                        // 機能名
                        tblList.add(Tbj28WorkLog.KNONM);
                    } else if (i == IDX_DSMNM) {
                        // 操作名
                        tblList.add(Tbj28WorkLog.DSMNM);
                    }
                }
            }
            tblList.add(" COUNT(*) AS LOG_COUNT ");

            retTbl = (String[])tblList.toArray(new String[0]);
        }

        return retTbl;
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {

        StringBuffer tbl = new StringBuffer();

        tbl.append(Tbj28WorkLog.TBNAME);

        return tbl.toString();
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
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

        return getFindOperationLogDAO();
    }

    /**
     * 稼働ログのSQL文を返します
     *
     * @return String SQL文
     */
    private String getFindOperationLogDAO()
    {
        StringBuffer sql = new StringBuffer();
        boolean andFlg = false;

        sql.append("SELECT ");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length - 1) {
                sql.append(", ");
            }
        }

        sql.append(" FROM ");
        sql.append(getTableName());

        sql.append(" WHERE ");

        if (!(_cond.getCrtDateFrom().isEmpty())) {
            // 対象期間(FROM)
            sql.append("TO_CHAR(" + Tbj28WorkLog.CRTDATE + ", 'YYYYMMDD') >= " + _cond.getCrtDateFrom() + " ");
            andFlg = true;
        }

        if (!(_cond.getCrtDateTo().isEmpty())) {
            // 対象期間(TO)
            if (andFlg) {
                sql.append(" AND ");
            }
            sql.append("TO_CHAR(" + Tbj28WorkLog.CRTDATE + ", 'YYYYMMDD') <= " + _cond.getCrtDateTo() + " ");
        }

        if (!(_cond.getHamId().isEmpty())) {
            // ESQID
            sql.append(" AND " + Tbj28WorkLog.HAMID + " LIKE '%" + _cond.getHamId() + "%'");
        }

        if (!(_cond.getHamNm().isEmpty())) {
            // 担当者名
            sql.append(" AND " + Tbj28WorkLog.HAMNM + " LIKE '%" + _cond.getHamNm() + "%'");
        }

        if (!(_cond.getSikNmKyk().isEmpty())) {
            // 組織名
//            sql.append(" AND ( " + Tbj28WorkLog.SIKNMKYK + " LIKE '%" + _cond.getSikNmKyk() + "%'");
//            sql.append(" OR " + Tbj28WorkLog.SIKNMSITU + " LIKE '%" + _cond.getSikNmKyk() + "%'");
//            sql.append(" OR " + Tbj28WorkLog.SIKNMBU + " LIKE '%" + _cond.getSikNmKyk() + "%'");
//            sql.append(" OR " + Tbj28WorkLog.SIKNMKA + " LIKE '%" + _cond.getSikNmKyk() + "%' ) ");
            sql.append(" AND ");
            sql.append(Tbj28WorkLog.SIKNMKYK);
            sql.append(COMBINE_SOSHIKI);
            sql.append(Tbj28WorkLog.SIKNMSITU);
            sql.append(COMBINE_SOSHIKI);
            sql.append(Tbj28WorkLog.SIKNMBU);
            sql.append(COMBINE_SOSHIKI);
            sql.append(Tbj28WorkLog.SIKNMKA);
            sql.append(" LIKE '%").append(_cond.getSikNmKyk()).append("%'");
        }

        if (!(_cond.getFormNm().isEmpty())) {
            // 画面名
            sql.append(" AND " + Tbj28WorkLog.FORMNM + " LIKE '%" + _cond.getFormNm() + "%'");
        }

        if (!(_cond.getKnoNm().isEmpty())) {
            // 機能名
            sql.append(" AND " + Tbj28WorkLog.KNONM + " LIKE '%" + _cond.getKnoNm() + "%'");
        }

        if (!(_cond.getDsmNm().isEmpty())) {
            // 操作名
            sql.append(" AND " + Tbj28WorkLog.DSMNM + " LIKE '%" + _cond.getDsmNm() + "%'");
        }

        if (_cond.getTotalFlg().indexOf(FLG_ON) == -1) {
            // 集計フラグが設定されていない場合

            // データ作成日時でソート
            sql.append(" ORDER BY ");
            sql.append(Tbj28WorkLog.CRTDATE);

        } else {
            // 集計フラグが設定されている場合

            /** GROUP BY 設定 **/

            sql.append(" GROUP BY ");

            String[] flgList = _cond.getTotalFlg().split(",");

            for (int i = 0; i < flgList.length; i++) {
                if (flgList[i].equals(FLG_ON)) {
                    if (i == IDX_CRTDATE) {
                        // 対象期間
                        sql.append("TO_CHAR(" + Tbj28WorkLog.CRTDATE + ", 'YYYY/MM/DD')" + ",");
                    } else if (i == IDX_HAMID) {
                        // ESQID
                        sql.append(Tbj28WorkLog.HAMID + ",");
                    } else if (i == IDX_HAMNM) {
                        // 担当者名
                        sql.append(Tbj28WorkLog.HAMNM + ",");
                    } else if (i == IDX_SOSHIKI_FULLNM) {
                        // 組織名
                        sql.append(Tbj28WorkLog.SIKNMKYK + ",");
                        sql.append(Tbj28WorkLog.SIKNMSITU + ",");
                        sql.append(Tbj28WorkLog.SIKNMBU + ",");
                        sql.append(Tbj28WorkLog.SIKNMKA + ",");

                    } else if (i == IDX_FORMNM) {
                        // 画面名
                        sql.append(Tbj28WorkLog.FORMNM + ",");
                    } else if (i == IDX_KNONM) {
                        // 機能名
                        sql.append(Tbj28WorkLog.KNONM + ",");
                    } else if (i == IDX_DSMNM) {
                        // 操作名
                        sql.append(Tbj28WorkLog.DSMNM + ",");
                    }
                }
            }
            // 最後の,を削除
            sql.deleteCharAt(sql.length() - 1);

            /** ORDER BY 設定 **/

            // データ作成日時でソート
            sql.append(" ORDER BY ");

            for (int i = 0; i < flgList.length; i++) {
                if (flgList[i].equals(FLG_ON)) {
                    if (i == IDX_CRTDATE) {
                        // 対象期間
                        sql.append(Tbj28WorkLog.CRTDATE + ",");
                    } else if (i == IDX_HAMID) {
                        // ESQID
                        sql.append(Tbj28WorkLog.HAMID + ",");
                    } else if (i == IDX_HAMNM) {
                        // 担当者名
                        sql.append(Tbj28WorkLog.HAMNM + ",");
                    } else if (i == IDX_SOSHIKI_FULLNM) {
                        // 組織名
                        sql.append(Tbj28WorkLog.SIKNMKYK + ",");
                        sql.append(Tbj28WorkLog.SIKNMSITU + ",");
                        sql.append(Tbj28WorkLog.SIKNMBU + ",");
                        sql.append(Tbj28WorkLog.SIKNMKA + ",");

                    } else if (i == IDX_FORMNM) {
                        // 画面名
                        sql.append(Tbj28WorkLog.FORMNM + ",");
                    } else if (i == IDX_KNONM) {
                        // 機能名
                        sql.append(Tbj28WorkLog.KNONM + ",");
                    } else if (i == IDX_DSMNM) {
                        // 操作名
                        sql.append(Tbj28WorkLog.DSMNM + ",");
                    }
                   }
            }
            // 最後の,を削除
            sql.deleteCharAt(sql.length() - 1);

        }

        return sql.toString();
    }

    /**
     * 稼働ログの検索を行います
     *
     * @return 稼働ログVOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<FindOperationLogVO> selectVO(FindOperationLogCondition cond) throws HAMException {

        List<FindOperationLogVO> result = null;

        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindOperationLogVO());

        try {
            _cond = cond;
            result = super.find();
            return result;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
