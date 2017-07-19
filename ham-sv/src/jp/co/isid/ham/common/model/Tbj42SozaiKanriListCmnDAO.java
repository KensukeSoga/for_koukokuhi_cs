package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj42SozaiKanriListCmn;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材一覧（共有）DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/03/09 HDX対応 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj42SozaiKanriListCmnDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj42SozaiKanriListCmnCondition _condition = null;

    /** 登録データ */
    private Tbj42SozaiKanriListCmnVO _vo = null;

    /** SqlMode */
    private enum SqlMode {DEFAULT, FIND, INS, UPD, DEL, UPDDELFLG, UPDTEMPMATERIAL};
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /** デフォルトコンストラクタ */
    public Tbj42SozaiKanriListCmnDAO() {
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
                Tbj42SozaiKanriListCmn.DCARCD
                ,Tbj42SozaiKanriListCmn.SOZAIYM
                ,Tbj42SozaiKanriListCmn.RECKBN
                ,Tbj42SozaiKanriListCmn.RECNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj42SozaiKanriListCmn.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj42SozaiKanriListCmn.CRTDATE
                ,Tbj42SozaiKanriListCmn.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj42SozaiKanriListCmn.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj42SozaiKanriListCmn.DCARCD
                ,Tbj42SozaiKanriListCmn.SOZAIYM
                ,Tbj42SozaiKanriListCmn.RECKBN
                ,Tbj42SozaiKanriListCmn.RECNO
                ,Tbj42SozaiKanriListCmn.DELFLG
                ,Tbj42SozaiKanriListCmn.CMCD
                ,Tbj42SozaiKanriListCmn.TEMPCMCD
                ,Tbj42SozaiKanriListCmn.ALIASTITLE
                ,Tbj42SozaiKanriListCmn.ENDTITLE
                ,Tbj42SozaiKanriListCmn.BSCSUSE
                ,Tbj42SozaiKanriListCmn.TIMEUSE
                ,Tbj42SozaiKanriListCmn.SPOTUSE
                ,Tbj42SozaiKanriListCmn.SPOTCTRT
                ,Tbj42SozaiKanriListCmn.SPOTFROM
                ,Tbj42SozaiKanriListCmn.SPOTTO
                ,Tbj42SozaiKanriListCmn.HMORDER
                ,Tbj42SozaiKanriListCmn.LAYOUTORDER
                ,Tbj42SozaiKanriListCmn.OANGSPAN
                ,Tbj42SozaiKanriListCmn.TARGET
                ,Tbj42SozaiKanriListCmn.CARNEWS
                ,Tbj42SozaiKanriListCmn.NEXTCARNEWS
                ,Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MVCHL
                ,Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE
                ,Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MXTV
                ,Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM
                ,Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS
                ,Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_FMJPN
                ,Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_WTCC
                ,Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER1
                ,Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER2
                ,Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER3
                ,Tbj42SozaiKanriListCmn.CRTDATE
                ,Tbj42SozaiKanriListCmn.CRTNM
                ,Tbj42SozaiKanriListCmn.CRTAPL
                ,Tbj42SozaiKanriListCmn.CRTID
                ,Tbj42SozaiKanriListCmn.UPDDATE
                ,Tbj42SozaiKanriListCmn.UPDNM
                ,Tbj42SozaiKanriListCmn.UPDAPL
                ,Tbj42SozaiKanriListCmn.UPDID
        };
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

    /** SELECT SQL */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.DEFAULT)) {
            sql = getSelectSQLTbj42SozaiKanriListCmnVO();
        } else if (_sqlMode.equals(SqlMode.FIND)) {
            sql = getSelectSQLFind();
        }

        return sql;
    };

    /**
     * SELECT SQL(Tbj42SozaiKanriListCmnVO)
     */
    private String getSelectSQLTbj42SozaiKanriListCmnVO() {

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
            Tbj42SozaiKanriListCmnVO vo = new Tbj42SozaiKanriListCmnVO();
            vo.setALIASTITLE(_condition.getAliastitle());
            vo.setBSCSUSE(_condition.getBscsuse());
            vo.setCARNEWS(_condition.getCarnews());
            vo.setCMCD(_condition.getCmcd());
            vo.setCRTAPL(_condition.getCrtapl());
            vo.setCRTDATE(_condition.getCrtdate());
            vo.setCRTID(_condition.getCrtid());
            vo.setCRTNM(_condition.getCrtnm());
            vo.setDCARCD(_condition.getDcarcd());
            vo.setDELFLG(_condition.getDelflg());
            vo.setENDTITLE(_condition.getEndtitle());
            vo.setHMORDER(_condition.getHmorder());
            vo.setLAYOUTORDER(_condition.getLayoutorder());
            vo.setNEXTCARNEWS(_condition.getNextcarnews());
            vo.setOANGSPAN(_condition.getOangspan());
            vo.setOTHERMEDIAUSE_CIRCUITVS(_condition.getOthermediause_circuitvs());
            vo.setOTHERMEDIAUSE_FMJPN(_condition.getOthermediause_fmjpn());
            vo.setOTHERMEDIAUSE_KYOSERADM(_condition.getOthermediause_kyoseradm());
            vo.setOTHERMEDIAUSE_MVCHL(_condition.getOthermediause_mvchl());
            vo.setOTHERMEDIAUSE_MXTV(_condition.getOthermediause_mxtv());
            vo.setOTHERMEDIAUSE_OTHER1(_condition.getOthermediause_other1());
            vo.setOTHERMEDIAUSE_OTHER2(_condition.getOthermediause_other2());
            vo.setOTHERMEDIAUSE_OTHER3(_condition.getOthermediause_other3());
            vo.setOTHERMEDIAUSE_WTCC(_condition.getOthermediause_wtcc());
            vo.setOTHERMEDIAUSE_YOUTUBE(_condition.getOthermediause_youtube());
            vo.setRECKBN(_condition.getReckbn());
            vo.setRECNO(_condition.getRecno());
            vo.setSOZAIYM(_condition.getSozaiym());
            vo.setSPOTCTRT(_condition.getSpotctrt());
            vo.setSPOTFROM(_condition.getSpotfrom());
            vo.setSPOTTO(_condition.getSpotto());
            vo.setSPOTUSE(_condition.getSpotuse());
            vo.setTARGET(_condition.getTarget());
            vo.setTEMPCMCD(_condition.getTempcmcd());
            vo.setTIMEUSE(_condition.getTimeuse());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDID(_condition.getUpdid());
            vo.setUPDNM(_condition.getUpdnm());

            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY");
        orderSql.append(" " + Tbj42SozaiKanriListCmn.CRTDATE + ",");
        orderSql.append(" " + Tbj42SozaiKanriListCmn.TEMPCMCD);

        return selectSql.toString() + whereSqlStr + orderSql.toString();
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
            sql.append(" " + Tbj42SozaiKanriListCmn.TBNAME);

            sql.append(" SET");

            sql.append(" " + Tbj42SozaiKanriListCmn.DELFLG + " = '" + _vo.getDELFLG() + "',");
            sql.append(" " + Tbj42SozaiKanriListCmn.UPDNM + " = '" + _vo.getUPDNM() + "',");
            sql.append(" " + Tbj42SozaiKanriListCmn.UPDAPL + " = '" + _vo.getUPDAPL() + "',");
            sql.append(" " + Tbj42SozaiKanriListCmn.UPDID + " = '" + _vo.getUPDID() + "'");

            sql.append(" WHERE");
            //本素材
            if(_vo.getCMCD() != null){
                sql.append(" " + Tbj42SozaiKanriListCmn.CMCD + " = '" + _vo.getCMCD() + "' AND");
            }else{
                sql.append(" " + Tbj42SozaiKanriListCmn.CMCD + " IS NULL AND");
            }
            //仮素材
            if(_vo.getTEMPCMCD() != null){
                sql.append(" " + Tbj42SozaiKanriListCmn.TEMPCMCD + " = '" + _vo.getTEMPCMCD() + "'");
            }else{
                sql.append(" " + Tbj42SozaiKanriListCmn.TEMPCMCD + " IS NULL");
            }
        }

        //本素材登録用
        if (_sqlMode.equals(SqlMode.UPDTEMPMATERIAL)) {

            sql.append("UPDATE");
            sql.append(" " + Tbj42SozaiKanriListCmn.TBNAME);

            sql.append(" SET");

            sql.append(" " + Tbj42SozaiKanriListCmn.CMCD + " = '" + _vo.getCMCD() + "',");
            sql.append(" " + Tbj42SozaiKanriListCmn.UPDNM + " = '" + _vo.getUPDNM() + "',");
            sql.append(" " + Tbj42SozaiKanriListCmn.UPDAPL + " = '" + _vo.getUPDAPL() + "',");
            sql.append(" " + Tbj42SozaiKanriListCmn.UPDID + " = '" + _vo.getUPDID() + "'");

            sql.append(" WHERE");
            sql.append(" " + Tbj42SozaiKanriListCmn.TEMPCMCD + " = '" + _vo.getTEMPCMCD() + "'");
            if (_vo.getSOZAIYM() != null) {
                sql.append(" AND " + Tbj42SozaiKanriListCmn.SOZAIYM + " = '" + DateUtil.toStringGeneral(_vo.getSOZAIYM(), "yyyy/MM/dd") + "'");
            }
        }

        //素材一覧(共通)削除
        if (_sqlMode.equals(SqlMode.DEL)) {

            sql.append("DELETE");
            sql.append(" FROM");
            sql.append(" " + Tbj42SozaiKanriListCmn.TBNAME);

            sql.append(" WHERE");
            //本素材
            if(_vo.getCMCD() != null){
                sql.append(" " + Tbj42SozaiKanriListCmn.CMCD + " = '" + _vo.getCMCD() + "' AND");
            }else{
                sql.append(" " + Tbj42SozaiKanriListCmn.CMCD + " IS NULL AND");
            }
            //仮素材
            if(_vo.getTEMPCMCD() != null){
                sql.append(" " + Tbj42SozaiKanriListCmn.TEMPCMCD + " = '" + _vo.getTEMPCMCD() + "'");
            }else{
                sql.append(" " + Tbj42SozaiKanriListCmn.TEMPCMCD + " IS NULL");
            }
        }

        return sql.toString();
    }

    /**
     * 素材一覧(共有)情報取得
     * @return 素材一覧(共有)情報取得SQL
     */
    private String getSelectSQLFind() {

        StringBuilder sql = new StringBuilder();

        sql.append(" SELECT");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append((i != 0 ? " ," : " "));
            sql.append(getTableColumnNames()[i] + " ");
        }

        sql.append(" FROM");
        sql.append(" " + getTableName());

        sql.append(" WHERE");
        sql.append(" " + Tbj42SozaiKanriListCmn.CMCD + " IS NULL");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj42SozaiKanriListCmn.CRTDATE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.TEMPCMCD);

        return sql.toString();
    }

    /**
     * insertVO
     * @param vo 登録VO
     * @throws HAMException
     */
    public void insertVO(Tbj42SozaiKanriListCmnVO vo) throws HAMException {

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
     * UpdateVO
     * @param vo データ
     * @throws HAMException
     */
    public void updateVO(Tbj42SozaiKanriListCmnVO vo) throws HAMException {

        // パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);
        _vo = vo;

        try {
            if (!super.update()) {
                throw new HAMException("更新エラー", "BJ-E0003");
            }
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * deleteVO
     * @param vo 削除VO
     * @throws HAMException
     */
    public void deleteVO(Tbj42SozaiKanriListCmnVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }

        super.setModel(vo);
        _sqlMode = SqlMode.DEL;
        _vo = vo;
        try {
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj42SozaiKanriListCmnVO> findVO(Tbj42SozaiKanriListCmnCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj42SozaiKanriListCmnVO());
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
    public List<Tbj42SozaiKanriListCmnVO> selectVO(Tbj42SozaiKanriListCmnCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj42SozaiKanriListCmnVO());
        _condition = condition;
        _sqlMode = SqlMode.DEFAULT;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 削除フラグ更新用SQL
     * @param vo 更新データ
     * @throws HAMException
     */
    public void updateDelFlg(Tbj42SozaiKanriListCmnVO vo) throws HAMException {

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
    public void updateTempMaterial(Tbj42SozaiKanriListCmnVO vo) throws HAMException {

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
}