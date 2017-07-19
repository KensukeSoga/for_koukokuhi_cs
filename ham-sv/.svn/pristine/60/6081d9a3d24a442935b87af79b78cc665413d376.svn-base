package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材一覧DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * ・JASRAC対応(2015/11/25 HLC K.Soga)<BR>
 * ・HDX対応(2016/02/18 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj20SozaiKanriListDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj20SozaiKanriListCondition _condition = null;
    private List<Tbj20SozaiKanriListVO> _conditions = null;

    /** SQLモード */
    private enum SqlMode {RCODE, MAXRECNO, MULTIPK, MULTICMCD, INS, UPD, NEWNO};
    private SqlMode _sqlMode = SqlMode.RCODE;

    /** デフォルトコンストラクタ */
    public Tbj20SozaiKanriListDAO() {
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
                Tbj20SozaiKanriList.DCARCD
                ,Tbj20SozaiKanriList.SOZAIYM
                ,Tbj20SozaiKanriList.RECKBN
                ,Tbj20SozaiKanriList.RECNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj20SozaiKanriList.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        if (_sqlMode.equals(SqlMode.INS)) {
            return new String[] {
                    Tbj20SozaiKanriList.CRTDATE
                    ,Tbj20SozaiKanriList.UPDDATE
            };
        } else if (_sqlMode.equals(SqlMode.UPD)) {
            return new String[] {
                    Tbj20SozaiKanriList.UPDDATE
            };
        } else {
            return new String[] { };
        }
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj20SozaiKanriList.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj20SozaiKanriList.DCARCD
                ,Tbj20SozaiKanriList.SOZAIYM
                ,Tbj20SozaiKanriList.RECKBN
                ,Tbj20SozaiKanriList.RECNO
                ,Tbj20SozaiKanriList.DELFLG
                ,Tbj20SozaiKanriList.CMCD
                ,Tbj20SozaiKanriList.TEMPCMCD
                ,Tbj20SozaiKanriList.TITLE
                ,Tbj20SozaiKanriList.SECOND
                ,Tbj20SozaiKanriList.RCODE
                ,Tbj20SozaiKanriList.ESTIMATE
                ,Tbj20SozaiKanriList.DATEFROM
                ,Tbj20SozaiKanriList.DATETO
                /** 2016/02/18 HDX対応 HLC K.Soga ADD Start */
                ,Tbj20SozaiKanriList.DATEFROM_ATTR
                ,Tbj20SozaiKanriList.DATETO_ATTR
                ,Tbj20SozaiKanriList.NEWDISPFLG
                ,Tbj20SozaiKanriList.OPENFLG
                ,Tbj20SozaiKanriList.HCSYATAN
                ,Tbj20SozaiKanriList.HMSYATAN
                /** 2016/02/18 HDX対応 HLC K.Soga ADD End */
                ,Tbj20SozaiKanriList.NEWFLG
                ,Tbj20SozaiKanriList.TIMEUSE
                ,Tbj20SozaiKanriList.SPOTUSE
                ,Tbj20SozaiKanriList.SPOTCTRT
                ,Tbj20SozaiKanriList.SPOTSPAN
                ,Tbj20SozaiKanriList.SPOTESTM
                ,Tbj20SozaiKanriList.LIMIT
                ,Tbj20SozaiKanriList.SYATAN
                ,Tbj20SozaiKanriList.BIKO
                ,Tbj20SozaiKanriList.FORECOLOR
                ,Tbj20SozaiKanriList.BACKCOLOR
                ,Tbj20SozaiKanriList.CRTDATE
                ,Tbj20SozaiKanriList.CRTNM
                ,Tbj20SozaiKanriList.CRTAPL
                ,Tbj20SozaiKanriList.CRTID
                ,Tbj20SozaiKanriList.UPDDATE
                ,Tbj20SozaiKanriList.UPDNM
                ,Tbj20SozaiKanriList.UPDAPL
                ,Tbj20SozaiKanriList.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        String sql = null;
        if (_sqlMode.equals(SqlMode.RCODE)) {
            sql = getSozaiKanriByRCode();
        } else if (_sqlMode.equals(SqlMode.MAXRECNO)) {
            sql = getMaxRecNoByConditoin();
        } else if (_sqlMode.equals(SqlMode.MULTIPK)) {
            sql = getSelectSQLForMultiPK();
        } else if (_sqlMode.equals(SqlMode.MULTICMCD)) {
            sql = getSelectSQLForMultiCmCd();
        /** 2016/03/10 HDX対応 HLC K.Soga ADD Start */
        } else if (_sqlMode.equals(SqlMode.NEWNO)) {
            sql = getFindNewNo();
        }
        /** 2016/03/10 HDX対応 HLC K.Soga ADD End */
        return sql;
    }

    /**
     * 略コードによる検索用SQL作成
     * @return String SQL文
     */
    private String getSozaiKanriByRCode() {
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
        sql.append(" WHERE ");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + " = '" + _condition.getRcode() + "' ");
        sql.append(" AND ");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = " + getDBModelInterface().ConvertToDBString(_condition.getSozaiym()) + " ");

        return sql.toString();
    }

    /**
     * 作成番号の最大値取得用SQL作成
     * @return String SQL文
     */
    private String getMaxRecNoByConditoin() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT TO_CHAR(NVL(MAX(" + Tbj20SozaiKanriList.RECNO + "),0) + 1,'FM0000') AS " + Tbj20SozaiKanriList.RECNO);
        sql.append("  FROM " + Tbj20SozaiKanriList.TBNAME);
        sql.append(" WHERE " + Tbj20SozaiKanriList.DCARCD + " = " + "'" + _condition.getDcarcd() + "'" );
        sql.append("   AND " + Tbj20SozaiKanriList.SOZAIYM + " = " + getDBModelInterface().ConvertToDBString(_condition.getSozaiym()));
        sql.append("   AND " + Tbj20SozaiKanriList.RECKBN + " = " + "'" + _condition.getReckbn() + "'" );

        return sql.toString();
    }

    /**
     * 複数PK検索用SQL作成
     * @return String 複数PK検索
     */
    private String getSelectSQLForMultiPK() {

        StringBuffer sql = new StringBuffer();

        // 排他用SQL
        sql.append(" SELECT ");
        sql.append(" " + getTimeStampKeyName() + " ");
        for (int i = 0; i < getPrimryKeyNames().length; i++) {
            sql.append(" ," + getPrimryKeyNames()[i] +" ");
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        for (int i = 0; i < _conditions.size(); i++) {
            AbstractModel cond = _conditions.get(i);
            sql.append((i != 0 ? " OR " : " "));
            sql.append(" ( ");
            for (int j = 0; j < getPrimryKeyNames().length; j++) {
                sql.append((j != 0 ? " AND " : " "));
                sql.append("" + getPrimryKeyNames()[j] +" ");
                sql.append(" = ");
                sql.append(getDBModelInterface().ConvertToDBString(cond.get(getPrimryKeyNames()[j])));
            }
            sql.append(" ) ");
        }

        return sql.toString();
    }

    /**
     * 10桁CMコード、年月で検索用SQL作成(排他チェック用)
     * @return String SQL文
     */
    private String getSelectSQLForMultiCmCd() {

        StringBuffer sql = new StringBuffer();

        /** 2015/11/24 JASRAC対応 HLC K.Soga MOD Start */
//        sql.append(" SELECT ");
//        sql.append(" " + getTimeStampKeyName() + " ");
//        for (int i = 0; i < getPrimryKeyNames().length; i++) {
//            sql.append(" ," + getPrimryKeyNames()[i] +" ");
//        }
//        sql.append(" FROM ");
//        sql.append(" " + getTableName() + " ");
//        sql.append(" WHERE ");
//        for (int i = 0; i < _conditions.size(); i++) {
//            Tbj20SozaiKanriListVO cond = _conditions.get(i);
//            sql.append((i != 0 ? " OR " : " "));
//            sql.append(" ( ");
//            sql.append("" + Tbj20SozaiKanriList.SOZAIYM +" ");
//            sql.append(" = ");
//            sql.append(getDBModelInterface().ConvertToDBString(cond.getSOZAIYM()));
//            sql.append(" AND ");
//            sql.append("" + Tbj20SozaiKanriList.CMCD +" ");
//            sql.append(" = ");
//            sql.append(getDBModelInterface().ConvertToDBString(cond.getCMCD()));
//            sql.append(" ) ");
//        }

        sql.append(" SELECT");
        sql.append(" " + getTimeStampKeyName() + " ");
        for (int i = 0; i < getPrimryKeyNames().length; i++) {
            sql.append(" ," + getPrimryKeyNames()[i] + " ");
        }

        sql.append(" FROM");
        sql.append(" " + getTableName() + " ");

        sql.append(" WHERE ");
        for (int i = 0; i < _conditions.size(); i++) {
            Tbj20SozaiKanriListVO cond = _conditions.get(i);
            sql.append((i != 0 ? " OR " : " "));
            sql.append(" (");
            sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = " + "' ' AND");
            sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = " + getDBModelInterface().ConvertToDBString(cond.getSOZAIYM()) + " AND");
            sql.append(" " + Tbj20SozaiKanriList.CMCD + " = " + getDBModelInterface().ConvertToDBString(cond.getCMCD()));
            sql.append(" ) ");
        }

        return sql.toString();
    }
    /** 2015/11/24 JASRAC対応 HLC K.Soga MOD End */

    /** 2016/03/10 HDX対応 HLC K.Soga ADD Start */
    /**
     * NewNo(RECNO)検索用SQL作成
     * @return String SQL文
     */
    private String getFindNewNo() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT");
        sql.append(" " + Tbj20SozaiKanriList.RECNO);

        sql.append(" FROM ");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME);

        sql.append(" WHERE");
        //本素材
        if(_condition.getCmcd() != null){
            sql.append(" " + Tbj20SozaiKanriList.CMCD + " = '" + _condition.getCmcd() + "' AND");
        }else{
            sql.append(" " + Tbj20SozaiKanriList.CMCD + " IS NULL AND");
        }
        //仮素材
        if(_condition.getTempcmcd() != null){
            sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " = '" + _condition.getTempcmcd() + "' AND");
        }else{
            sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " IS NULL AND");
        }
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = '" + DateUtil.toString(_condition.getSozaiym()) + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + " = '" + _condition.getReckbn() + "'");

        return sql.toString();
    }
    /** 2016/03/10 HDX対応 HLC K.Soga ADD End */

    /**
     * 略コードによる検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj20SozaiKanriListVO> FindSozaiKanriByRCode(Tbj20SozaiKanriListCondition cond) throws HAMException {

        super.setModel(new Tbj20SozaiKanriListVO());

        try {
            _sqlMode = SqlMode.RCODE;
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 作成番号の最大値取得
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj20SozaiKanriListVO> findMaxRecNoByConditoin(Tbj20SozaiKanriListCondition cond) throws HAMException {

        super.setModel(new Tbj20SozaiKanriListVO());

        try {
            _sqlMode = SqlMode.MAXRECNO;
            _condition = cond;
            return (List<Tbj20SozaiKanriListVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 複数PK条件での検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj20SozaiKanriListVO> selectByMultiPk(List<Tbj20SozaiKanriListVO> cond) throws HAMException {

        // パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj20SozaiKanriListVO());

        try {
            _sqlMode = SqlMode.MULTIPK;
            _conditions = cond;
            return (List<Tbj20SozaiKanriListVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 10桁CMコード、年月で検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj20SozaiKanriListVO> selectByMultiCmCd(List<Tbj20SozaiKanriListVO> cond) throws HAMException {

        // パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj20SozaiKanriListVO());

        try {
            _sqlMode = SqlMode.MULTICMCD;
            _conditions = cond;
            return (List<Tbj20SozaiKanriListVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /** 2016/03/10 HDX対応 HLC K.Soga ADD Start */
    /**
     * 作成番号(NewNo/RECNO)検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj20SozaiKanriListVO> FindNewNo(Tbj20SozaiKanriListCondition cond) throws HAMException {

        super.setModel(new Tbj20SozaiKanriListVO());

        try {
            _sqlMode = SqlMode.NEWNO;
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
    /** 2016/03/10 HDX対応 HLC K.Soga ADD End */

    /**
     * 登録処理
     * @param vo 登録VO
     * @throws HAMException
     */
    public void insertVO(Tbj20SozaiKanriListVO vo) throws HAMException {

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
     * 更新処理
     * @param vo 更新VO
     * @throws HAMException
     */
    public void updateVO(Tbj20SozaiKanriListVO vo) throws HAMException {

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
     * 削除処理
     * @param vo 削除VO
     * @throws HAMException
     */
    public void deleteVO(Tbj20SozaiKanriListVO vo) throws HAMException {

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
}