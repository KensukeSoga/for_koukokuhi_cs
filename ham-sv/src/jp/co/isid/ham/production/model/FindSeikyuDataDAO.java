package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj46Ths;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu07SikKrSprd;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu12ThsKgy;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu13ThsKgyBmon;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu14ThsTntTr;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

public class FindSeikyuDataDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private FindSeikyuDataCondition _cond = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode {
        SEIKYU, SEIKYU_H,
    };

    private SelSqlMode _SelSqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindSeikyuDataDAO() {
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

        if (_SelSqlMode.equals(SelSqlMode.SEIKYU)) {
            sql = getSelectSQLForSEIKYU();
        } else if (_SelSqlMode.equals(SelSqlMode.SEIKYU_H)) {
            sql = getSelectSQLForSEIKYU_H();
        }

        return sql;
    };

    private String getSelectSQLForSEIKYU() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append("  " + RepaVbjaMeu14ThsTntTr.THSKGYCD   + " AS " + "THSKGYCD");
        sql.append(" ," + RepaVbjaMeu14ThsTntTr.SEQNO      + " AS " + "SEQNO");
        sql.append(" ,' ' AS " + "TNTSEQNO");
        sql.append(" ," + RepaVbjaMeu12ThsKgy.THSKGYDISPKJ + " AS " + "THSKGYDISPKJ");
        sql.append(" ," + RepaVbjaMeu12ThsKgy.THSKGYLNGKJ  + " AS " + "THSKGYLNGKJ");
        sql.append(" ," + RepaVbjaMeu13ThsKgyBmon.SUBMEI   + " AS " + "SUBMEI");
        sql.append(" ,' ' AS " + "CLASSDIV");
        sql.append(" FROM ");
        sql.append("  " + "REP_VBJ_MEU12THSKGY ");
        sql.append(" ," + "REP_VBJ_MEU13THSKGYBMON ");
        sql.append(" ," + RepaVbjaMeu14ThsTntTr.TBNAME);
        sql.append(" ," + RepaVbjaMeu07SikKrSprd.TBNAME);
        sql.append(" WHERE  ");
        sql.append("     " + ConvertToDBString(_cond.getBaseDate()) + " BETWEEN " + RepaVbjaMeu12ThsKgy.STARTYMD + " AND " + RepaVbjaMeu12ThsKgy.ENDYMD);
        sql.append(" AND " + RepaVbjaMeu12ThsKgy.THSKGYCD + " = " + RepaVbjaMeu13ThsKgyBmon.THSKGYCD);
        sql.append(" AND " + ConvertToDBString(_cond.getBaseDate()) + " BETWEEN " + RepaVbjaMeu13ThsKgyBmon.STARTYMD + " AND " + RepaVbjaMeu13ThsKgyBmon.ENDYMD);
        sql.append(" AND " + RepaVbjaMeu13ThsKgyBmon.THSKGYCD + " = " + RepaVbjaMeu14ThsTntTr.THSKGYCD);
        sql.append(" AND " + RepaVbjaMeu13ThsKgyBmon.SEQNO    + " = " + RepaVbjaMeu14ThsTntTr.SEQNO);
        sql.append(" AND " + RepaVbjaMeu12ThsKgy.THSKGYCD + " = " + RepaVbjaMeu14ThsTntTr.THSKGYCD);
        sql.append(" AND " + ConvertToDBString(_cond.getBaseDate()) + " BETWEEN " + RepaVbjaMeu14ThsTntTr.STARTYMD + " AND " + RepaVbjaMeu14ThsTntTr.ENDYMD);
        sql.append(" AND " + RepaVbjaMeu14ThsTntTr.TKKBN    + " != " + "'0'");
        sql.append(" AND " + RepaVbjaMeu14ThsTntTr.EGSYOCD  + " = " + "'" + _cond.getEgsCd() + "'");
        sql.append(" AND " + RepaVbjaMeu07SikKrSprd.SIKCD   + " = " + RepaVbjaMeu14ThsTntTr.SIKCD);
        sql.append(" AND " + ConvertToDBString(_cond.getBaseDate()) + " BETWEEN " + RepaVbjaMeu07SikKrSprd.STARTYMD + " AND    " + RepaVbjaMeu07SikKrSprd.ENDYMD);
        sql.append(" AND " + "(" + RepaVbjaMeu07SikKrSprd.IOCD + " NOT LIKE '__2X990' AND " + RepaVbjaMeu07SikKrSprd.IOCD + " NOT LIKE '__2X000')");
//        if (!StringUtil.isBlank(_cond.getKykCd())) {
//            sql.append(" AND " + RepaVbjaMeu07SikKrSprd.SIKCDKYK    + "  = " + ConvertToDBString(_cond.getKykCd()));
//        }
        //↓コードマスタに定義されているAM局の組織コードで絞り込み-----------
        sql.append(" AND " + RepaVbjaMeu07SikKrSprd.SIKCDKYK + " IN (");
        sql.append(" SELECT ");
        sql.append(" " + Mbj12Code.YOBI1);
        sql.append(" FROM ");
        sql.append(" " + Mbj12Code.TBNAME);
        sql.append(" WHERE ");
        sql.append("     " + Mbj12Code.CODETYPE + " = '24' ");
        sql.append(" AND " + Mbj12Code.YOBI2 + " = '1'");
        sql.append(" )");
        //-------------------------------------------------------------------
        if (!StringUtil.isBlank(_cond.getName())) {
            sql.append(" AND ( ");
            if (_cond.getSearchKind() == 1) {
                sql.append("     " + RepaVbjaMeu12ThsKgy.THSKGYKN        + "  LIKE '" + getCharacterString(_cond.getName()) + "%'");
                sql.append(" OR  " + RepaVbjaMeu12ThsKgy.THSKGYSRCHKN    + "  LIKE '" + getCharacterString(_cond.getName()) + "%'");
            } else if (_cond.getSearchKind() == 2) {
                sql.append("     " + RepaVbjaMeu12ThsKgy.THSKGYKN        + "  LIKE '%" + getCharacterString(_cond.getName()) + "%'");
                sql.append(" OR  " + RepaVbjaMeu12ThsKgy.THSKGYSRCHKN    + "  LIKE '%" + getCharacterString(_cond.getName()) + "%'");
            }
            sql.append(" ) ");
        }
        sql.append(" GROUP BY  ");
        sql.append("  " + RepaVbjaMeu14ThsTntTr.THSKGYCD);
        sql.append(" ," + RepaVbjaMeu14ThsTntTr.SEQNO);
        sql.append(" ," + RepaVbjaMeu12ThsKgy.THSKGYDISPKJ);
        sql.append(" ," + RepaVbjaMeu12ThsKgy.THSKGYLNGKJ);
        sql.append(" ," + RepaVbjaMeu13ThsKgyBmon.SUBMEI);
        sql.append(" ORDER BY  ");
        sql.append("  " + RepaVbjaMeu14ThsTntTr.THSKGYCD);
        sql.append(" ," + RepaVbjaMeu14ThsTntTr.SEQNO);
        //sql.append(" ," + RepaVbjaMeu14ThsTntTr.TRTNTSEQNO);

        return sql.toString();
    }

    private String getSelectSQLForSEIKYU_H() {
        StringBuffer sql = new StringBuffer();

        //※HAM取引先マスタに登録されている請求先を表示する場合のSQL
        sql.append(" SELECT ");
        sql.append("  " + RepaVbjaMeu13ThsKgyBmon.THSKGYCD      + " AS " + "THSKGYCD");
        sql.append(" ," + RepaVbjaMeu13ThsKgyBmon.SEQNO         + " AS " + "SEQNO");
        sql.append(" ,' ' AS " + "TNTSEQNO");
        sql.append(" ," + RepaVbjaMeu12ThsKgy.THSKGYDISPKJ      + " AS " + "THSKGYDISPKJ");
        sql.append(" ," + RepaVbjaMeu12ThsKgy.THSKGYLNGKJ       + " AS " + "THSKGYLNGKJ");
        sql.append(" ," + RepaVbjaMeu13ThsKgyBmon.SUBMEI        + " AS " + "SUBMEI");
        sql.append(" ," + Mbj46Ths.CLASSDIV                     + " AS " + "CLASSDIV");
        sql.append(" FROM ");
        sql.append("  " + "REP_VBJ_MEU12THSKGY ");
        sql.append(" ," + "REP_VBJ_MEU13THSKGYBMON ");
        sql.append(" ," + RepaVbjaMeu14ThsTntTr.TBNAME);
        sql.append(" ," + RepaVbjaMeu07SikKrSprd.TBNAME);
        sql.append(" ," + Mbj46Ths.TBNAME);
        sql.append(" WHERE  ");
        sql.append("     " + ConvertToDBString(_cond.getBaseDate()) + " BETWEEN " + RepaVbjaMeu12ThsKgy.STARTYMD + " AND " + RepaVbjaMeu12ThsKgy.ENDYMD);
        sql.append(" AND " + RepaVbjaMeu12ThsKgy.THSKGYCD + " = " + RepaVbjaMeu13ThsKgyBmon.THSKGYCD);
        sql.append(" AND " + ConvertToDBString(_cond.getBaseDate()) + " BETWEEN " + RepaVbjaMeu13ThsKgyBmon.STARTYMD + " AND " + RepaVbjaMeu13ThsKgyBmon.ENDYMD);
        sql.append(" AND " + RepaVbjaMeu13ThsKgyBmon.THSKGYCD + " = " + RepaVbjaMeu14ThsTntTr.THSKGYCD);
        sql.append(" AND " + RepaVbjaMeu13ThsKgyBmon.SEQNO    + " = " + RepaVbjaMeu14ThsTntTr.SEQNO);
        sql.append(" AND " + RepaVbjaMeu12ThsKgy.THSKGYCD + " = " + RepaVbjaMeu14ThsTntTr.THSKGYCD);
        sql.append(" AND " + ConvertToDBString(_cond.getBaseDate()) + " BETWEEN " + RepaVbjaMeu14ThsTntTr.STARTYMD + " AND " + RepaVbjaMeu14ThsTntTr.ENDYMD);
        sql.append(" AND " + RepaVbjaMeu14ThsTntTr.TKKBN    + " != " + "'0'");
        sql.append(" AND " + RepaVbjaMeu14ThsTntTr.EGSYOCD  + " = " + "'" + _cond.getEgsCd() + "'");
        sql.append(" AND " + RepaVbjaMeu07SikKrSprd.SIKCD   + " = " + RepaVbjaMeu14ThsTntTr.SIKCD);
        sql.append(" AND " + ConvertToDBString(_cond.getBaseDate()) + " BETWEEN " + RepaVbjaMeu07SikKrSprd.STARTYMD + " AND    " + RepaVbjaMeu07SikKrSprd.ENDYMD);
        sql.append(" AND " + "(" + RepaVbjaMeu07SikKrSprd.IOCD + " NOT LIKE '__2X990' AND " + RepaVbjaMeu07SikKrSprd.IOCD + " NOT LIKE '__2X000')");

        if (!StringUtil.isBlank(_cond.getName())) {
            sql.append(" AND ( ");
            if (_cond.getSearchKind() == 1) {
                sql.append("     " + RepaVbjaMeu12ThsKgy.THSKGYKN        + "  LIKE '" + getCharacterString(_cond.getName()) + "%'");
                sql.append(" OR  " + RepaVbjaMeu12ThsKgy.THSKGYSRCHKN    + "  LIKE '" + getCharacterString(_cond.getName()) + "%'");
            } else if (_cond.getSearchKind() == 2) {
                sql.append("     " + RepaVbjaMeu12ThsKgy.THSKGYKN        + "  LIKE '%" + getCharacterString(_cond.getName()) + "%'");
                sql.append(" OR  " + RepaVbjaMeu12ThsKgy.THSKGYSRCHKN    + "  LIKE '%" + getCharacterString(_cond.getName()) + "%'");
            }
            sql.append(" ) ");
        }

//        sql.append(" AND EXISTS (");
//        sql.append("         SELECT");
//        sql.append("             'DUMMY'");
//        sql.append("         FROM");
//        sql.append("             " + Mbj46Ths.TBNAME);
//        sql.append("         WHERE");
//        sql.append("             " + Mbj46Ths.THSKGYCD + " = " + RepaVbjaMeu13ThsKgyBmon.THSKGYCD");
//        sql.append("         AND " + Mbj46Ths.SEQNO    + " = " + RepaVbjaMeu13ThsKgyBmon.SEQNO");
//        sql.append("         AND " + Mbj46Ths.TRTHKBN  + " = " + "'0'");
//        sql.append("     )");
        sql.append(" AND " + Mbj46Ths.THSKGYCD + " = " + RepaVbjaMeu13ThsKgyBmon.THSKGYCD);
        sql.append(" AND " + Mbj46Ths.SEQNO    + " = " + RepaVbjaMeu13ThsKgyBmon.SEQNO);
        sql.append(" AND " + Mbj46Ths.TRTHKBN  + " = " + "'0'");
        sql.append(" GROUP BY  ");
        sql.append("  " + RepaVbjaMeu13ThsKgyBmon.THSKGYCD);
        sql.append(" ," + RepaVbjaMeu13ThsKgyBmon.SEQNO);
        sql.append(" ," + RepaVbjaMeu12ThsKgy.THSKGYDISPKJ);
        sql.append(" ," + RepaVbjaMeu12ThsKgy.THSKGYLNGKJ);
        sql.append(" ," + RepaVbjaMeu13ThsKgyBmon.SUBMEI);
        sql.append(" ," + Mbj46Ths.CLASSDIV);
        sql.append(" ORDER BY  ");
        sql.append("  MAX(" + Mbj46Ths.SORTNO + ")");//PKが検索or集計の条件になっているのでMAXでも問題ないはず.
        sql.append(" ," + RepaVbjaMeu12ThsKgy.THSKGYDISPKJ);
        sql.append(" ," + RepaVbjaMeu13ThsKgyBmon.THSKGYCD);
        sql.append(" ," + RepaVbjaMeu13ThsKgyBmon.SEQNO);

        return sql.toString();
    }

    /**
     * 一覧の請求先のリストに表示するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<SeikyuDataVO> findSeikyuData(FindSeikyuDataCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new SeikyuDataVO());
        try {
            _SelSqlMode = SelSqlMode.SEIKYU;
            _cond = cond;
            return (List<SeikyuDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 一覧の請求先のリストに表示するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<SeikyuDataVO> findSeikyuDataH(FindSeikyuDataCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new SeikyuDataVO());
        try {
            _SelSqlMode = SelSqlMode.SEIKYU_H;
            _cond = cond;
            return (List<SeikyuDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    ///**
    //* Modelの生成を行う<br>
    //* 検索結果のVOのKEYが大文字のため変換処理を行う<br>
    //* AbstractRdbDaoのcreateFindedModelInstancesをオーバーライド<br>
    //*
    //* @param hashList List 検索結果
    //* @return List<CommonCodeMasterVO> 変換後の検索結果
    //*/
    //@Override
    //@SuppressWarnings("unchecked")
    //protected List createFindedModelInstances(List hashList) {
    //List list = null;
    //if (getModel() instanceof MaterialRegisterCntrctVO) {
    //list = new ArrayList<MaterialRegisterCntrctVO>();
    //for (int i = 0; i < hashList.size(); i++) {
    //Map result = (Map) hashList.get(i);
    //MaterialRegisterCntrctVO vo = new MaterialRegisterCntrctVO();
    //vo.setCMCD((String)result.get(Tbj17Content.CMCD.toUpperCase()));
    //vo.setCTRTKBN((String)result.get(Tbj16ContractInfo.CTRTKBN.toUpperCase()));
    //vo.setCTRTNO((String)result.get(Tbj16ContractInfo.CTRTNO.toUpperCase()));
    //vo.setNAMES((String)result.get(Tbj16ContractInfo.NAMES.toUpperCase()));
    //vo.setDATEFROM(DateUtil.toDate((String)result.get(Tbj16ContractInfo.DATEFROM.toUpperCase())));
    //vo.setDATETO(DateUtil.toDate((String)result.get(Tbj16ContractInfo.DATETO.toUpperCase())));
    //vo.setMUSIC((String)result.get(Tbj16ContractInfo.MUSIC.toUpperCase()));
    //vo.setSALEFLG((String)result.get(Tbj16ContractInfo.SALEFLG.toUpperCase()));
    //vo.setCRTDATE(DateUtil.toDate((String)result.get(Tbj16ContractInfo.CRTDATE.toUpperCase())));
    //vo.setUPDDATE(DateUtil.toDate((String)result.get(Tbj16ContractInfo.UPDDATE.toUpperCase())));
    //vo.setUPDNM((String)result.get(Tbj16ContractInfo.UPDNM.toUpperCase()));
    //vo.setUPDAPL((String)result.get(Tbj16ContractInfo.UPDAPL.toUpperCase()));
    //vo.setUPDID((String)result.get(Tbj16ContractInfo.UPDID.toUpperCase()));
    //vo.setDCARCD((String)result.get(Tbj16ContractInfo.DCARCD.toUpperCase()));
    //vo.setCATEGORY((String)result.get(Tbj16ContractInfo.CATEGORY.toUpperCase()));
    //vo.setJASRACFLG((String)result.get(Tbj16ContractInfo.JASRACFLG.toUpperCase()));
    //
    //// 検索結果直後の状態にする
    //ModelUtils.copyMemberSearchAfterInstace(vo);
    //list.add(vo);
    //}
    //}
    //return list;
    //}

    //============================================================================================================================

    private String ConvertToDBString(Object obj) {
        return super.getDBModelInterface().ConvertToDBString(obj);
    }

    private String getCharacterString(String str) {
        return super.getDBModelInterface().getCharacterString(str);
    }

}
