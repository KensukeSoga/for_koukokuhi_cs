package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj44LogSozaiKanriListCmnVO;
import jp.co.isid.ham.integ.tbl.Tbj42SozaiKanriListCmn;
import jp.co.isid.ham.integ.tbl.Tbj44LogSozaiKanriListCmn;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
*
* <P>
* 素材一覧ログ(共有)DAO<P>
* <B>修正履歴</B><BR>
* ・新規作成(2016/03/10 HDX対応 HLC K.Soga)<BR>
* </P>
* @author
*/
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RegisterLogMaterialListCmnDAO extends AbstractRdbDao {

    /** 更新用VO(Tbj44) */
    private Tbj44LogSozaiKanriListCmnVO _vo = null;

    /** EXEC-SQLモード */
    private enum ExcSqlMode {INSLOG};

    /** トランザクションSQLモード変数 */
    private ExcSqlMode _ExcSqlMode = null;

    /** デフォルトコンストラクタ */
    public RegisterLogMaterialListCmnDAO() {
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
        if (_ExcSqlMode.equals(ExcSqlMode.INSLOG)) {
            sql = getExecSQLForInsertLogMaterialListCmn();
        }
        return sql;
    }

    /**
     * 素材一覧(共有)ログを作成するSQLを取得
     * @return
     */
    private String getExecSQLForInsertLogMaterialListCmn() {

        Tbj44LogSozaiKanriListCmnVO vo = (Tbj44LogSozaiKanriListCmnVO)super.getModel();
        StringBuffer sql = new StringBuffer();

        sql.append("INSERT");
        sql.append(" INTO " + Tbj44LogSozaiKanriListCmn.TBNAME);
        sql.append(" (");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.DCARCD + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.SOZAIYM + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.RECKBN + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.RECNO + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.HISTORYNO + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.HISTORYKBN + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.DELFLG + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.CMCD + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.TEMPCMCD + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.ALIASTITLE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.ENDTITLE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.BSCSUSE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.TIMEUSE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTUSE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTCTRT + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTFROM + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTTO + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.HMORDER + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.LAYOUTORDER + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OANGSPAN + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.TARGET + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.CARNEWS + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.NEXTCARNEWS + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MVCHL + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MXTV + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_FMJPN + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_WTCC + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER1 + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER2 + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER3 + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.CRTDATE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.CRTNM + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.CRTAPL + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.CRTID + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.UPDDATE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.UPDNM + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.UPDAPL + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.UPDID);
        sql.append(" )");

        sql.append(" SELECT");
        sql.append(" " + Tbj42SozaiKanriListCmn.DCARCD + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SOZAIYM + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.RECKBN + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.RECNO + ",");
        sql.append(" '" + _vo.getHISTORYNO() + "',");
        sql.append(" '" + _vo.getHISTORYKBN() + "',");
        sql.append(" " + Tbj42SozaiKanriListCmn.DELFLG + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.CMCD + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.TEMPCMCD + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.ALIASTITLE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.ENDTITLE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.BSCSUSE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.TIMEUSE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTUSE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTCTRT + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTFROM + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTTO + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.HMORDER + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.LAYOUTORDER + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OANGSPAN + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.TARGET + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.CARNEWS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.NEXTCARNEWS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MVCHL + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MXTV + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_FMJPN + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_WTCC + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER1 + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER2 + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER3 + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.CRTDATE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.CRTNM + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.CRTAPL + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.CRTID + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.UPDDATE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.UPDNM + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.UPDAPL + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.UPDID);

        sql.append(" FROM");
        sql.append(" " + Tbj42SozaiKanriListCmn.TBNAME);
        StringBuffer sbWhere = new StringBuffer();

        if (vo.getDCARCD() != null) {
            sbWhere.append(" " + Tbj42SozaiKanriListCmn.DCARCD + " = '" + vo.getDCARCD() + "'");
        }
        if (vo.getSOZAIYM() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND");
            sbWhere.append(" " + Tbj42SozaiKanriListCmn.SOZAIYM + " = '" +  DateUtil.toString(vo.getSOZAIYM()) + "'");
        }
        if (vo.getRECKBN() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND");
            sbWhere.append(" " + Tbj42SozaiKanriListCmn.RECKBN + " = '" + vo.getRECKBN() + "'");
        }
        if (vo.getRECNO() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND");
            sbWhere.append(" " + Tbj42SozaiKanriListCmn.RECNO + " = '" + vo.getRECNO() + "'");
        }
        if (vo.getCMCD() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND");
            sbWhere.append(" " + Tbj42SozaiKanriListCmn.CMCD + " = '" + vo.getCMCD() + "'");
        }
        if (vo.getTEMPCMCD() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND");
            sbWhere.append(" " + Tbj42SozaiKanriListCmn.TEMPCMCD + " = '" + vo.getTEMPCMCD() + "'");
        }
        if (sbWhere.length() > 0) {
            sql.append(" WHERE");
            sql.append(" " + sbWhere.toString());
        }

        return sql.toString();
    }

    /**
     * 素材一覧(共有)ログテーブルに追加します
     * @param vo
     * @throws HAMException
     */
    public void insertMaterialListCmnLog(Tbj44LogSozaiKanriListCmnVO vo) throws HAMException {
        if (vo == null)
            throw new HAMException("登録エラー", "BJ-E0008");

        super.setModel(vo);
        try {
            _ExcSqlMode = ExcSqlMode.INSLOG;
            _vo = vo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }
}