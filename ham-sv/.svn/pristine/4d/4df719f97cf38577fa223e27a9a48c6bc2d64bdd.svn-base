package jp.co.isid.ham.login.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mfk01Kkh;
import jp.co.isid.ham.integ.tbl.Mfk02Jun;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu00Sik;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu07SikKrSprd;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu12ThsKgy;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu13ThsKgyBmon;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu14ThsTntTr;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu16Skukjk;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu29Cc;
import jp.co.isid.ham.integ.tbl.Vbj02TitleClassGroupInfo;
import jp.co.isid.ham.integ.tbl.Vbj03TitleClassMember;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

public class MprKengenCheckDAO extends AbstractSimpleRdbDao {

    /** 範囲フラグ：ON */
   private static final String ZHANNIGF_ON = "1";

   /** 範囲フラグ：OFF */
   private static final String ZHANNIGF_OFF = "0";

   /** 受発注登録可フラグ：ON */
   private static final String ZJYUHACHU_ON = "1";

   /** ステータス：正常 */
   private static final String ZSBCH0103_NORMAL = "O";

    SyokuiGrpInfoCondition _skiGrpCondition = null;
    EigyosyoInfoCondition _egyCondition = null;
    TksInfoCondition _tksCondition = null;
    KhUnMstCondition _kkhCondition = null;
    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode {
        SKIGRP,EGY,TKS,KKH,
    };

    private SelSqlMode _SelSqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public MprKengenCheckDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
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

        if (_SelSqlMode.equals(SelSqlMode.SKIGRP)) {
            sql = getSelectSQLForSKIGRP();
        } else if (_SelSqlMode.equals(SelSqlMode.EGY)) {
            sql = getSelectSQLForEGY();
        } else if (_SelSqlMode.equals(SelSqlMode.TKS)) {
            sql = getSelectSQLForTKS();
        } else if (_SelSqlMode.equals(SelSqlMode.KKH)) {
            sql = getSelectSQLForKKH();
        }

        return sql;
    };

    private String getSelectSQLForSKIGRP() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append(" " + Vbj03TitleClassMember.GROUPCD + " ");
        sql.append(" FROM ");
        sql.append(" " + Vbj02TitleClassGroupInfo.TBNAME + " ");
        sql.append(" ," + Vbj03TitleClassMember.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Vbj02TitleClassGroupInfo.GROUPCD + " = " + Vbj03TitleClassMember.GROUPCD + " ");
        sql.append(" AND ");
        sql.append(" " + Vbj02TitleClassGroupInfo.STRTYMD + " <= '" + _skiGrpCondition.getEigyobi() + "' ");
        sql.append(" AND ");
        sql.append(" " + Vbj02TitleClassGroupInfo.STPYMD + " >= '" + _skiGrpCondition.getEigyobi() + "' ");
        sql.append(" AND ");
        sql.append(" " + Vbj03TitleClassMember.ESQID + " = '" + _skiGrpCondition.getEsqId() + "' ");

        return sql.toString();
    }

    private String getSelectSQLForEGY() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT /*+ ordered */ ");
        sql.append("  " + RepaVbjaMeu29Cc.NAIYJ + " ");
        sql.append(" ," + RepaVbjaMeu00Sik.EGSYOCD + " ");
        sql.append(" ," + RepaVbjaMeu00Sik.JSIKCD + " ");
        sql.append(" ," + RepaVbjaMeu00Sik.KAISOCD + " ");
        sql.append(" FROM ");
        sql.append(" " + RepaVbjaMeu00Sik.TBNAME + " ");
        sql.append(" ," + RepaVbjaMeu29Cc.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMeu00Sik.SIKCD + " = " + ConvertToDBString(_egyCondition.getTntSikCd()) + " ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu00Sik.STARTYMD + " <= " + ConvertToDBString(_egyCondition.getEigyobi()) + " ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu00Sik.ENDYMD + " >= " + ConvertToDBString(_egyCondition.getEigyobi()) + " ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu29Cc.HKYMD + " <= " + ConvertToDBString(_egyCondition.getEigyobi()) + " ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu29Cc.HAISYMD + " >= '99999999' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu29Cc.KYCDKND + " = '91' ");

        return sql.toString();
    }

    private String getSelectSQLForTKS() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT /*+ ordered */ ");
        sql.append("  " + RepaVbjaMeu14ThsTntTr.THSKGYCD + " ");
        sql.append(" ," + RepaVbjaMeu14ThsTntTr.SEQNO + " ");
        sql.append(" ," + RepaVbjaMeu14ThsTntTr.TRTNTSEQNO + " ");
        sql.append(" ," + RepaVbjaMeu14ThsTntTr.SIKCD + " ");
        sql.append(" ," + "CASE WHEN " + RepaVbjaMeu14ThsTntTr.CLNTKBN + " <>'1' THEN " + RepaVbjaMeu14ThsTntTr.CLNTKGYCD + " ELSE " + RepaVbjaMeu14ThsTntTr.THSKGYCD + " END AS " + RepaVbjaMeu14ThsTntTr.CLNTKGYCD + " ");
        sql.append(" ," + "CASE WHEN " + RepaVbjaMeu14ThsTntTr.CLNTKBN + " <>'1' THEN " + RepaVbjaMeu14ThsTntTr.CLNTSEQNO + " ELSE " + RepaVbjaMeu14ThsTntTr.SEQNO + " END AS " + RepaVbjaMeu14ThsTntTr.CLNTSEQNO + " ");
        sql.append(" ," + RepaVbjaMeu16Skukjk.SINCD + " ");
        sql.append(" ," + RepaVbjaMeu12ThsKgy.DTENKBN + " ");
        sql.append(" ," + RepaVbjaMeu12ThsKgy.THSKGYDISPKJ + " ");
        sql.append(" ," + RepaVbjaMeu13ThsKgyBmon.SUBMEI + " ");
        sql.append(" ," + RepaVbjaMeu13ThsKgyBmon.GSYLMCD + " ");
        sql.append(" ," + RepaVbjaMeu07SikKrSprd.SIKCDKYK + " ");
        sql.append(" ," + RepaVbjaMeu07SikKrSprd.SIKCDBU + " ");
        sql.append(" ," + RepaVbjaMeu07SikKrSprd.BUHYOJIKJ + " ");
        sql.append(" ," + RepaVbjaMeu14ThsTntTr.KYUTRCD + " ");
        sql.append(" FROM ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.TBNAME + " ");
        sql.append(" ," + RepaVbjaMeu12ThsKgy.TBNAME + " ");
        sql.append(" ," + RepaVbjaMeu13ThsKgyBmon.TBNAME + " ");
        sql.append(" ," + RepaVbjaMeu16Skukjk.TBNAME + " ");
        sql.append(" ," + RepaVbjaMeu07SikKrSprd.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.THSKGYCD + " = " + ConvertToDBString(_tksCondition.getTksKgyCd()));
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.SEQNO + " = " + ConvertToDBString(_tksCondition.getTksBmnSeqNo()));
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.TKKBN + " = '1' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.EGSYOCD + " = "+ ConvertToDBString(_tksCondition.getEgsCd()));
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.ENDYMD + " ='99999999'");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.SIKCD + " = "+ ConvertToDBString(_tksCondition.getSikcd()));
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu13ThsKgyBmon.ENDYMD + " ='99999999'");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu12ThsKgy.ENDYMD + " ='99999999'");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu16Skukjk.ENDYMD + " ='99999999'");
        sql.append(" AND ");
        sql.append(" " + ConvertToDBString(_tksCondition.getEigyobi()) + " BETWEEN " + RepaVbjaMeu07SikKrSprd.STARTYMD + " AND " + RepaVbjaMeu07SikKrSprd.ENDYMD);
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.THSKGYCD + " = " + RepaVbjaMeu12ThsKgy.THSKGYCD);
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.THSKGYCD + " = " + RepaVbjaMeu13ThsKgyBmon.THSKGYCD);
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.THSKGYCD + " = " + RepaVbjaMeu16Skukjk.THSKGYCD);
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.SEQNO + " = " + RepaVbjaMeu13ThsKgyBmon.SEQNO);
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.SEQNO + " = " + RepaVbjaMeu16Skukjk.SEQNO);
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.TRTNTSEQNO + " = " + RepaVbjaMeu16Skukjk.TRTNTSEQNO);
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.SIKCD + " = " + RepaVbjaMeu07SikKrSprd.SIKCD);


        return sql.toString();
    }

    private String getSelectSQLForKKH() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append(" /*+ ordered */ ");
        sql.append(" " + Mfk02Jun.ZSBCH0317 + " ");
        sql.append(" FROM ");
        sql.append("  " + Mfk01Kkh.TBNAME + ", " + Mfk02Jun.TBNAME);
        sql.append(" WHERE ");
        sql.append(" ((" + Mfk01Kkh.ZHANNIGF + " = '" + ZHANNIGF_ON + "' ");
        sql.append(" AND ");
        sql.append(" " + Mfk01Kkh.ZSBCH0105 + " = '" + _kkhCondition.getJSikCd() + "' ) ");//上位組織コード
        sql.append(" OR ");
        sql.append(" ( " + Mfk01Kkh.ZHANNIGF + " = '" + ZHANNIGF_OFF + "' ");
        sql.append(" AND ");
        sql.append(" " + Mfk01Kkh.ZSBCH0105 + " = '" + _kkhCondition.getOperationNo() + "' )) ");//所属組織
        sql.append(" AND ");
        sql.append(" " + Mfk01Kkh.ZTOUKYU + " IN ( " + _kkhCondition.getSyokuiGrpCd() + " ) ");//メタディレクトリの職位等級グループ
        sql.append(" AND ");
        sql.append(" " + Mfk01Kkh.ZSBCH0110 + " IN ( " + _kkhCondition.getTntCd() + " ) ");// 担当者ID  担当者コードに'*'を加える
        sql.append(" AND ");
        sql.append(" " + Mfk01Kkh.DATEFROM + " <= '" + _kkhCondition.getEigyobi() + "' ");
        sql.append(" AND ");
        sql.append(" " + Mfk01Kkh.DATETO + " >= '" + _kkhCondition.getEigyobi() + "' ");
        sql.append(" AND ");
        sql.append(" " + Mfk01Kkh.ZJYUHACHU + " = '" + ZJYUHACHU_ON + "' ");
        sql.append(" AND ");
        sql.append(" " + Mfk01Kkh.ZDELFG + " IS NULL ");
        sql.append(" AND ");
        sql.append(" " + Mfk02Jun.ZSBCH0317 + " = '" + _kkhCondition.getTksCd() + "' ");//得意先コードを指定
        sql.append(" AND ");
        sql.append(" " + Mfk02Jun.DATEFROM + " <= '" + _kkhCondition.getEigyobi() + "' ");
        sql.append(" AND ");
        sql.append(" " + Mfk02Jun.DATETO + " >= '" + _kkhCondition.getEigyobi() + "' ");
        sql.append(" AND ");
        sql.append(" " + Mfk02Jun.ZSBCH0211 + " <= '" + _kkhCondition.getTermBegin() + "' ");//keikaku + "04"
        sql.append(" AND ");
        sql.append(" " + Mfk02Jun.ZSBCH0212 + " >= '" + _kkhCondition.getTermEnd() + "' ");// keikaku + 1 + "03"
        sql.append(" AND ");
        sql.append(" " + Mfk02Jun.ZSBCH0103 + " = '" + ZSBCH0103_NORMAL + "' ");
        sql.append(" AND ");
        sql.append(" " + Mfk01Kkh.ZSBCH0100 + " = " + Mfk02Jun.ZSBCH0100);
        sql.append(" AND ROWNUM = 1");

        return sql.toString();
    }

    /**
     * 画面で指定した条件で検索を行い、一覧に表示するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<SyokuiGrpInfoVO> getSyokuiGrpInfo(SyokuiGrpInfoCondition cond) throws HAMException {
        // パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new SyokuiGrpInfoVO());
        try {
            _SelSqlMode = SelSqlMode.SKIGRP;
            _skiGrpCondition = cond;
            return (List<SyokuiGrpInfoVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 営業所情報の検索を行います
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<EigyosyoInfoVO> getEigyosyoInfo(EigyosyoInfoCondition cond) throws HAMException {
        // パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new EigyosyoInfoVO());
        try {
            _SelSqlMode = SelSqlMode.EGY;
            _egyCondition = cond;
            return (List<EigyosyoInfoVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 得意先情報の検索を行います
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<TksInfoVO> getTksInfo(TksInfoCondition cond) throws HAMException {
        // パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new TksInfoVO());
        try {
            _SelSqlMode = SelSqlMode.TKS;
            _tksCondition = cond;
            return (List<TksInfoVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 公開範囲マスタの検索を行います
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<KhUnMstVO> getKhUnMstInfo(KhUnMstCondition cond) throws HAMException {
        // パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new KhUnMstVO());
        try {
            _SelSqlMode = SelSqlMode.KKH;
            _kkhCondition = cond;
            return (List<KhUnMstVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    private String ConvertToDBString(Object obj) {
        return super.getDBModelInterface().ConvertToDBString(obj);
    }

}
