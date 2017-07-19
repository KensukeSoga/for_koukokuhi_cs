package jp.co.isid.ham.common.model;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj43SozaiKanriListCmnOA;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材一覧（共有OA期間）DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/29 HLC HDX対応 K.Soga)<BR>
 * ・HDX不具合対応(2016/06/14 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj43SozaiKanriListCmnOADAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj43SozaiKanriListCmnOACondition _condition = null;

    /** 登録データ */
    private Tbj43SozaiKanriListCmnOAVO _vo = null;

    /** 作成番号Nullフラグ */
    private String _flg = null;

    /** SqlMode */
    private enum SqlMode {DEFAULT, FIND, INS, UPD, MAXSOZAIYM, FINDSOZAIYM ,FINDTHREEMONTH, UPDDELFLG, UPDTEMPMATERIAL, FINDMATERIALLIST};

    /** 選択SQLモード変数 */
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /** デフォルトコンストラクタ */
    public Tbj43SozaiKanriListCmnOADAO() {
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
                Tbj43SozaiKanriListCmnOA.DCARCD
                ,Tbj43SozaiKanriListCmnOA.SOZAIYM
                ,Tbj43SozaiKanriListCmnOA.RECKBN
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj43SozaiKanriListCmnOA.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj43SozaiKanriListCmnOA.CRTDATE
                ,Tbj43SozaiKanriListCmnOA.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj43SozaiKanriListCmnOA.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj43SozaiKanriListCmnOA.DCARCD
                ,Tbj43SozaiKanriListCmnOA.SOZAIYM
                ,Tbj43SozaiKanriListCmnOA.RECKBN
                ,Tbj43SozaiKanriListCmnOA.RECNO
                ,Tbj43SozaiKanriListCmnOA.DELFLG
                ,Tbj43SozaiKanriListCmnOA.CMCD
                ,Tbj43SozaiKanriListCmnOA.TEMPCMCD
                ,Tbj43SozaiKanriListCmnOA.OADATETERM
                ,Tbj43SozaiKanriListCmnOA.CRTDATE
                ,Tbj43SozaiKanriListCmnOA.CRTNM
                ,Tbj43SozaiKanriListCmnOA.CRTAPL
                ,Tbj43SozaiKanriListCmnOA.CRTID
                ,Tbj43SozaiKanriListCmnOA.UPDDATE
                ,Tbj43SozaiKanriListCmnOA.UPDNM
                ,Tbj43SozaiKanriListCmnOA.UPDAPL
                ,Tbj43SozaiKanriListCmnOA.UPDID
        };
    }

    /** SELECT SQL */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.DEFAULT)) {
            //Tbj43SozaiKanriListCmnOAVO取得用SQL取得
            sql = getSelectSQLTbj43SozaiKanriListCmnOAVO();
        } else if (_sqlMode.equals(SqlMode.MAXSOZAIYM)) {
            //素材年月の最大値取得
            sql = getMaxSozaiYm();
        } else if (_sqlMode.equals(SqlMode.FINDSOZAIYM)) {
            //素材年月の取得
            sql = getSozaiYm();
        } else if (_sqlMode.equals(SqlMode.FINDTHREEMONTH)) {
            //素材年月から三ヶ月間分取得
            sql = getSozaiThreeMonth();
        } else if (_sqlMode.equals(SqlMode.FINDMATERIALLIST)) {
            //10桁CMコードで素材一覧(共通OA期間)を取得
            sql = getMaterialListCmnOA();
        }
        return sql;
    };

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getExecString() {

        StringBuffer sql = new StringBuffer();

        //削除フラグ更新用
        if (_sqlMode.equals(SqlMode.UPDDELFLG)) {

            sql.append("UPDATE");
            sql.append(" " + Tbj43SozaiKanriListCmnOA.TBNAME);

            sql.append(" SET");

            sql.append(" " + Tbj43SozaiKanriListCmnOA.DELFLG + " = '" + _vo.getDELFLG() + "',");
            sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDNM + " = '" + _vo.getUPDNM() + "',");
            sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDAPL + " = '" + _vo.getUPDAPL() + "',");
            sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDID + " = '" + _vo.getUPDID() + "'");

            sql.append(" WHERE");
            //本素材
            if(_vo.getCMCD() != null){
                sql.append(" " + Tbj43SozaiKanriListCmnOA.CMCD + " = '" + _vo.getCMCD() + "' AND");
            }else{
                sql.append(" " + Tbj43SozaiKanriListCmnOA.CMCD + " IS NULL AND");
            }
            //仮素材
            if(_vo.getTEMPCMCD() != null){
                sql.append(" " + Tbj43SozaiKanriListCmnOA.TEMPCMCD + " = '" + _vo.getTEMPCMCD() + "'");
            }else{
                sql.append(" " + Tbj43SozaiKanriListCmnOA.TEMPCMCD + " IS NULL");
            }
        }

        //本素材登録用
        if (_sqlMode.equals(SqlMode.UPDTEMPMATERIAL)) {

            sql.append("UPDATE");
            sql.append(" " + Tbj43SozaiKanriListCmnOA.TBNAME);

            sql.append(" SET");
            sql.append(" " + Tbj43SozaiKanriListCmnOA.CMCD + " = '" + _vo.getCMCD() + "',");
            if(_vo.getSOZAIYM() != null){
                sql.append(" " + Tbj43SozaiKanriListCmnOA.SOZAIYM + " = TO_DATE('" + DateUtil.toStringGeneral(_vo.getSOZAIYM(), "yyyy/MM/dd HH:mm:ss") + "', 'YYYY-MM-DD HH24:MI:SS'),");
            }
            sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDNM + " = '" + _vo.getUPDNM() + "',");
            sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDAPL + " = '" + _vo.getUPDAPL() + "',");
            sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDID + " = '" + _vo.getUPDID() + "'");

            sql.append(" WHERE");
            sql.append(" " + Tbj43SozaiKanriListCmnOA.TEMPCMCD + " = '" + _vo.getTEMPCMCD() + "'");
            if (_vo.getSOZAIYM() != null) {
                sql.append(" AND TO_CHAR(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + ", 'yyyy/MM/dd') = '" + DateUtil.toStringGeneral(_vo.getSOZAIYM(), "yyyy/MM/dd") + "'");
            }
        }

        return sql.toString();
    }

    /**
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo)
    {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            Object value = vo.get(getTableColumnNames()[i]);
            if (value != null) {
                if (sql.length() == 0) {
                    sql.append(" WHERE ");
                } else {
                    sql.append(" AND ");
                }
                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /**
     * SELECT SQL(Tbj43SozaiKanriListCmnOAVO)
     */
    private String getSelectSQLTbj43SozaiKanriListCmnOAVO() {

        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";
        StringBuffer orderSql = new StringBuffer();

        selectSql.append(" SELECT");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }

        selectSql.append(" FROM");
        selectSql.append(" " + getTableName() + " ");

        if (_condition != null) {
            Tbj43SozaiKanriListCmnOAVO vo = new Tbj43SozaiKanriListCmnOAVO();
            vo.setCMCD(_condition.getCmcd());
            vo.setCRTAPL(_condition.getCrtapl());
            vo.setCRTDATE(_condition.getCrtdate());
            vo.setCRTID(_condition.getCrtid());
            vo.setCRTNM(_condition.getCrtnm());
            vo.setDCARCD(_condition.getDcarcd());
            vo.setDELFLG(_condition.getDelflg());
            vo.setRECKBN(_condition.getReckbn());
            vo.setRECNO(_condition.getRecno());
            vo.setSOZAIYM(_condition.getSozaiym());
            vo.setTEMPCMCD(_condition.getTempcmcd());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDID(_condition.getUpdid());
            vo.setUPDNM(_condition.getUpdnm());

            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY");
        orderSql.append(" " + Tbj43SozaiKanriListCmnOA.CRTDATE);

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * 素材年月の最大値取得用SQL作成
     * @return String SQL文
     */
    private String getMaxSozaiYm() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT");
        sql.append(" MAX(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + ") + 1 / 86400 " + Tbj43SozaiKanriListCmnOA.SOZAIYM);

        sql.append(" FROM");
        sql.append(" "+ Tbj43SozaiKanriListCmnOA.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.DCARCD + " = '" + _condition.getDcarcd() + "' AND");
        sql.append(" TO_CHAR(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + ", 'YYYYMMDD') = '" + DateUtil.toString(_condition.getSozaiym()) + "' AND");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.RECKBN + " = '" + _condition.getReckbn() + "'");

        return sql.toString();
    }

    /**
     * 素材年月の取得用SQL作成
     * @return String SQL文
     */
    private String getSozaiYm() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.SOZAIYM + ",");
        /** 2016/06/15 HDX不具合対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj43SozaiKanriListCmnOA.OADATETERM);
        /** 2016/06/15 HDX不具合対応 HLC K.Soga ADD End */

        sql.append(" FROM");
        sql.append(" "+ Tbj43SozaiKanriListCmnOA.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.DCARCD + " = '" + _condition.getDcarcd() + "' AND");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.RECKBN + " = '" + _condition.getReckbn() + "' AND");
        sql.append(" TO_CHAR(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + ", 'YYYYMMDD') = '" + DateUtil.toString(_condition.getSozaiym()) + "'");
        if(_condition.getCmcd() != null){
            sql.append(" AND " + Tbj43SozaiKanriListCmnOA.CMCD + " = '" + _condition.getCmcd() + "'");
        }
        if(_condition.getTempcmcd() != null){
            sql.append(" AND " + Tbj43SozaiKanriListCmnOA.TEMPCMCD + " = '" + _condition.getTempcmcd() + "'");
        }

        return sql.toString();
    }

    /**
     * 特定年月から3ヶ月分取得のOA期間SQL作成
     * @return String SQL文
     */
    private String getSozaiThreeMonth() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append(" " + getTableColumnNames()[i]);
            } else {
                sql.append(" ," + getTableColumnNames()[i]);
            }
        }

        sql.append(" FROM");
        sql.append(" "+ Tbj43SozaiKanriListCmnOA.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + "TO_CHAR(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + ", 'YYYYMM')");

        // カレンダークラスのインスタンスを取得
        Calendar cal = Calendar.getInstance();
        cal.setTime(_condition.getSozaiym());
        //三ヶ月分の年月設定
        sql.append(" IN('"+ new SimpleDateFormat("yyyyMM").format(cal.getTime()) + "',");
        cal.add(Calendar.MONTH, 1);
        sql.append(" '" + new SimpleDateFormat("yyyyMM").format(cal.getTime()) + "',");
        cal.add(Calendar.MONTH, 1);
        sql.append(" '" + new SimpleDateFormat("yyyyMM").format(cal.getTime()) + "')");

        return sql.toString();
    }

    /**
     * 10桁CMコードで素材一覧(共通OA期間)を取得
     * @return String SQL文
     */
    private String getMaterialListCmnOA() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append(" " + getTableColumnNames()[i]);
            } else {
                sql.append(" ," + getTableColumnNames()[i]);
            }
        }
        sql.append(" FROM");
        sql.append(" "+ Tbj43SozaiKanriListCmnOA.TBNAME);
        sql.append(" WHERE");
        if(_condition.getCmcd() != null){
            sql.append(" " + Tbj43SozaiKanriListCmnOA.CMCD + " = '" + _condition.getCmcd() + "' AND");
        }
        if(_condition.getTempcmcd() != null){
            sql.append(" " + Tbj43SozaiKanriListCmnOA.TEMPCMCD + " = '" + _condition.getTempcmcd() + "' AND");
        }
        //作成番号がNULLではない素材検索用
        if(_flg.equals(HAMConstants.RECNO_IS_NOT_NULL)){
            sql.append(" TO_CHAR(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + ", 'YYYYMMDD') = '" + DateUtil.toString(_condition.getSozaiym()) + "' AND");
            sql.append(" " + Tbj43SozaiKanriListCmnOA.RECNO + " IS NOT NULL AND");
        //作成番号がNULLの素材検索用
        }else{
            sql.append(" " + Tbj43SozaiKanriListCmnOA.RECNO + " IS NULL AND");
        }
        sql.append(" " + Tbj43SozaiKanriListCmnOA.DELFLG + " <> '" + HAMConstants.DELFLG + "'");
        return sql.toString();
    }

    /**
     * insertVO
     * @param vo 登録VO
     * @throws HAMException
     */
    public void insertVO(Tbj43SozaiKanriListCmnOAVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }

        super.setModel(vo);
        _sqlMode = SqlMode.INS;

        try {
            super.insert();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * updateVO
     * @param vo 更新VO
     * @throws HAMException
     */
    public void updateVO(Tbj43SozaiKanriListCmnOAVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }

        super.setModel(vo);
        _sqlMode = SqlMode.UPD;

        try {
            super.update();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * deleteVO
     * @param vo 削除VO
     * @throws HAMException
     */
    public void deleteVO(Tbj43SozaiKanriListCmnOAVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }

        super.setModel(vo);

        try {
            super.remove();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj43SozaiKanriListCmnOAVO> findVO(Tbj43SozaiKanriListCmnOACondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj43SozaiKanriListCmnOAVO());
        _condition = condition;
        _sqlMode = SqlMode.FIND;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj43SozaiKanriListCmnOAVO> selectVO(Tbj43SozaiKanriListCmnOACondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj43SozaiKanriListCmnOAVO());
        _condition = condition;
        _sqlMode = SqlMode.DEFAULT;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 素材年月の最大値取得
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj43SozaiKanriListCmnOAVO> findMaxSozaiYm(Tbj43SozaiKanriListCmnOACondition cond) throws HAMException {

        super.setModel(new Tbj43SozaiKanriListCmnOAVO());

        try {
            _sqlMode = SqlMode.MAXSOZAIYM;
            _condition = cond;
            return (List<Tbj43SozaiKanriListCmnOAVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 特定の素材年月取得
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj43SozaiKanriListCmnOAVO> findSozaiYm(Tbj43SozaiKanriListCmnOACondition cond) throws HAMException {

        super.setModel(new Tbj43SozaiKanriListCmnOAVO());

        try {
            _sqlMode = SqlMode.FINDSOZAIYM;
            _condition = cond;
            return (List<Tbj43SozaiKanriListCmnOAVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 特定の年月から3ヶ月間分OA期間取得
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj43SozaiKanriListCmnOAVO> findSozaiThreeMonth(Tbj43SozaiKanriListCmnOACondition cond) throws HAMException {

        super.setModel(new Tbj43SozaiKanriListCmnOAVO());

        try {
            _sqlMode = SqlMode.FINDTHREEMONTH;
            _condition = cond;
            return (List<Tbj43SozaiKanriListCmnOAVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 削除フラグ更新用SQL
     * @param vo 更新データ
     * @throws HAMException
     */
    public void updateDelFlg(Tbj43SozaiKanriListCmnOAVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);

        try {
            _vo = vo;
            _sqlMode = SqlMode.UPDDELFLG;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * 本素材登録用SQL
     * @param vo 更新データ
     * @throws HAMException
     */
    public void updateTempMaterial(Tbj43SozaiKanriListCmnOAVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);

        try {
            _vo = vo;
            _sqlMode = SqlMode.UPDTEMPMATERIAL;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * 10桁CMコードで素材一覧(共通OA期間)を取得：作成番号がNOT NULL用
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj43SozaiKanriListCmnOAVO> findMaterialListCmnOA(Tbj43SozaiKanriListCmnOACondition cond, String recNoFlg) throws HAMException {

        super.setModel(new Tbj43SozaiKanriListCmnOAVO());

        try {
            _sqlMode = SqlMode.FINDMATERIALLIST;
            _condition = cond;
            _flg = recNoFlg;
            return (List<Tbj43SozaiKanriListCmnOAVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}