package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOACondition;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOAVO;
import jp.co.isid.ham.integ.tbl.Tbj43SozaiKanriListCmnOA;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
*
* <P>
* 素材一覧(共通OA期間)DAO<P>
* <B>修正履歴</B><BR>
* ・新規作成(2016/03/10 HDX対応 HLC K.Soga)<BR>
* </P>
* @author
*/
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class UpdateMaterialListCmnOADAO extends AbstractRdbDao {

    /** 更新用VO(Tbj43) */
    private Tbj43SozaiKanriListCmnOAVO _vo = null;

    /** 更新用Cond(Tbj43) */
    private Tbj43SozaiKanriListCmnOACondition _cond = null;

    /** 本素材・仮素材フラグ */
    private String _materialType = null;

    /**
     * EXEC-SQLモード
     */
    private enum ExcSqlMode {UPD, UPDDCARCD, REGCMCD};

    /**
     * トランザクションSQLモード変数
     */
    private ExcSqlMode _ExcSqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public UpdateMaterialListCmnOADAO() {
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
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * EXEC-SQL文を返します
     */
    @Override
    public String getExecString() {
        String sql = "";
        if (_ExcSqlMode.equals(ExcSqlMode.UPD)) {
            sql = getUpdSQLMaterialListCmnOA();
        }else if (_ExcSqlMode.equals(ExcSqlMode.UPDDCARCD)) {
            sql = getUpdDcarCd();
        }else if (_ExcSqlMode.equals(ExcSqlMode.REGCMCD)) {
            sql = getRegCmcd();
        }
        return sql;
    }

    /**
     * 素材一覧(共通OA期間)更新SQLを作成する
     * @return String 素材一覧(共通OA期間)更新SQL
     */
    private String getUpdSQLMaterialListCmnOA() {

        StringBuffer sql = new StringBuffer();

        sql.append("UPDATE");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.TBNAME);

        sql.append(" SET");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.RECNO + " = '" + _vo.getRECNO() + "',");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.DCARCD + " = '" + _vo.getDCARCD() + "',");
        if(_vo.getSOZAIYM() != null){
            sql.append(" " + Tbj43SozaiKanriListCmnOA.SOZAIYM + " = TO_DATE('" + DateUtil.toStringGeneral(_vo.getSOZAIYM(), "yyyy/MM/dd HH:mm:ss") + "', 'YYYY-MM-DD HH24:MI:SS'),");
        }
        sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDDATE + " = " + getDBModelInterface().getSystemDateString() + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDAPL + " = '" + _vo.getUPDAPL() + "',");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDID + " = '" + _vo.getUPDID() + "'");

        sql.append(" WHERE");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.RECKBN + " = '0'");
        if (_materialType.equals(HAMConstants.MATERIAL_KBN_ACTUAL)) {
            //本素材
            sql.append(" AND " + Tbj43SozaiKanriListCmnOA.CMCD + " = '" + _vo.getCMCD() + "'");
        } else {
            //仮素材
            sql.append(" AND " + Tbj43SozaiKanriListCmnOA.TEMPCMCD + " = '" + _vo.getTEMPCMCD() + "'");
        }
        if (_vo.getSOZAIYM() != null) {
            sql.append(" AND TO_CHAR(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + ", 'yyyy/MM/dd') = '" + DateUtil.toStringGeneral(_vo.getSOZAIYM(), "yyyy/MM/dd") + "'");
        }

        return sql.toString();
    };

    /**
     * 素材一覧(共通OA期間)電通車種コード更新SQLを作成する
     * @return 素材一覧(共通OA期間)電通車種コード更新SQL
     */
    private String getUpdDcarCd() {

        StringBuffer sql = new StringBuffer();

        sql.append("UPDATE");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.TBNAME);

        sql.append(" SET");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.DCARCD + " = '" + _cond.getDcarcd() + "',");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.SOZAIYM + " = TO_DATE('" + DateUtil.toStringGeneral(_cond.getSozaiym(), "yyyy/MM/dd HH:mm:ss") + "', 'YYYY-MM-DD HH24:MI:SS'),");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDDATE + " = " + getDBModelInterface().getSystemDateString() + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDAPL + " = '" + _cond.getUpdapl() + "',");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDID + " = '" + _cond.getUpdid() + "'");

        sql.append(" WHERE");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.RECNO + " IS NULL AND");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.DELFLG + " <> '" + HAMConstants.DELFLG + "'");
        //本素材
        if (_cond.getCmcd() != null) {
            sql.append(" AND " + Tbj43SozaiKanriListCmnOA.CMCD + " = '" + _cond.getCmcd() + "'");
        }
        //仮素材
        if(_cond.getTempcmcd() != null){
            sql.append(" AND " + Tbj43SozaiKanriListCmnOA.TEMPCMCD + " = '" + _cond.getTempcmcd() + "'");
        }
        if (_cond.getSozaiym() != null) {
            sql.append(" AND TO_CHAR(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + ", 'yyyy/MM/dd') = '" + DateUtil.toStringGeneral(_cond.getSozaiym(), "yyyy/MM/dd") + "'");
        }

        return sql.toString();
    };

    /**
     * 素材一覧(共通OA期間)本素材登録時のSQLを作成する
     */
    private String getRegCmcd() {

        StringBuffer sql = new StringBuffer();

        sql.append("UPDATE");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.TBNAME);

        sql.append(" SET");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.DCARCD + " = '" + _cond.getDcarcd() + "',");
        if(_cond.getTempcmcd() != null){
            sql.append(" " + Tbj43SozaiKanriListCmnOA.CMCD + " = '" + _cond.getCmcd() + "',");
        }
        sql.append(" " + Tbj43SozaiKanriListCmnOA.SOZAIYM + " = TO_DATE('" + DateUtil.toStringGeneral(_cond.getSozaiym(), "yyyy/MM/dd HH:mm:ss") + "', 'YYYY-MM-DD HH24:MI:SS'),");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDDATE + " = " + getDBModelInterface().getSystemDateString() + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDAPL + " = '" + _cond.getUpdapl() + "',");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDID + " = '" + _cond.getUpdid() + "'");

        sql.append(" WHERE");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.RECNO + " IS NULL AND");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.DELFLG + " <> '" + HAMConstants.DELFLG + "'");
        if(_cond.getTempcmcd() != null){
            sql.append(" AND " + Tbj43SozaiKanriListCmnOA.TEMPCMCD + " = '" + _cond.getTempcmcd() + "'");
        }
        if (_cond.getSozaiym() != null) {
            sql.append(" AND TO_CHAR(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + ", 'yyyy/MM/dd') = '" + DateUtil.toStringGeneral(_cond.getSozaiym(), "yyyy/MM/dd") + "'");
        }

        return sql.toString();
    };

    /**
     * 素材一覧(共通OA期間)更新
     * @param vo 更新VO
     * @throws HAMException
     */
    public void updateSQLMaterialListCmnOA(Tbj43SozaiKanriListCmnOAVO vo, String materialType) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }

        try {
            _vo = vo;
            _materialType = materialType;
            _ExcSqlMode = ExcSqlMode.UPD;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * 素材一覧(共通OA期間)電通車種コード更新
     * @param vo 更新VO
     * @throws HAMException
     */
    public void updateDcarCd(Tbj43SozaiKanriListCmnOACondition cond) throws HAMException {

        //パラメータチェック
        if (cond == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }

        try {
            _cond = cond;
            _ExcSqlMode = ExcSqlMode.UPDDCARCD;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * 本素材登録
     * @param vo 更新VO
     * @throws HAMException
     */
    public void RegisterCmCd(Tbj43SozaiKanriListCmnOACondition cond) throws HAMException {

        //パラメータチェック
        if (cond == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }

        try {
            _cond = cond;
            _ExcSqlMode = ExcSqlMode.REGCMCD;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }
}