package jp.co.isid.ham.media.model;


import java.math.BigDecimal;

import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
*
* <P>
* 営業作業台帳の情報取得DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2012/12/14 HLC H.Watabe)<BR>
* </P>
*
* @author HLC H.Watabe
*/
public class AccountBookRegisterDAO extends AbstractSimpleRdbDao{


    private Tbj02EigyoDaichoVO _vo =null;

    private BigDecimal _updMediaPlan;

    private enum SqlMode{INS,DEL,UPD};

    private enum ExecSqlMode{UPD};

    private SqlMode _sqlmode = SqlMode.INS;

    private ExecSqlMode _execsqlmode =ExecSqlMode.UPD;


    /**
     * デフォルトコンストラクタ
     */
    public AccountBookRegisterDAO() {
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
        return new String[]{
                Tbj02EigyoDaicho.MEDIAPLANNO,
                Tbj02EigyoDaicho.DAICHONO
        };

    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return Tbj02EigyoDaicho.CRTDATE;

    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        if (_sqlmode.equals(SqlMode.INS)) {
            return new String[]{
                    Tbj02EigyoDaicho.CRTDATE,
                    Tbj02EigyoDaicho.UPDDATE
            };
        } else if (_sqlmode.equals(SqlMode.UPD)) {
            return new String[]{
                    Tbj02EigyoDaicho.UPDDATE
            };
        }

        return null;

    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return Tbj02EigyoDaicho.TBNAME;

    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{
                Tbj02EigyoDaicho.MEDIAPLANNO
                ,Tbj02EigyoDaicho.DAICHONO
                ,Tbj02EigyoDaicho.IMPKEY
                ,Tbj02EigyoDaicho.SEIKYUYM
                ,Tbj02EigyoDaicho.MEDIACD
                ,Tbj02EigyoDaicho.MEDIASCD
                ,Tbj02EigyoDaicho.MEDIASNM
                ,Tbj02EigyoDaicho.KEIRETSUCD
                ,Tbj02EigyoDaicho.DCARCD
                ,Tbj02EigyoDaicho.HIYOUNO
                ,Tbj02EigyoDaicho.KIKAKUNO
                ,Tbj02EigyoDaicho.CAMPAIGN
                ,Tbj02EigyoDaicho.NAIYOHIMOKU
                ,Tbj02EigyoDaicho.SPACE
                ,Tbj02EigyoDaicho.NPDIVISION
                ,Tbj02EigyoDaicho.PUBLISHVER
                ,Tbj02EigyoDaicho.SYMBOLDIVISION
                ,Tbj02EigyoDaicho.POSTEDSURFACE
                ,Tbj02EigyoDaicho.UNIT
                ,Tbj02EigyoDaicho.CONTRACTDIVISION
                ,Tbj02EigyoDaicho.KIKANFROM
                ,Tbj02EigyoDaicho.KIKANTO
                ,Tbj02EigyoDaicho.GENKAFLG
                ,Tbj02EigyoDaicho.GROSS
                ,Tbj02EigyoDaicho.DNEBIKIRITSU
                ,Tbj02EigyoDaicho.DNEBIKIGAKU
                ,Tbj02EigyoDaicho.HMCOST
                ,Tbj02EigyoDaicho.APLRIEKIRITSU
                ,Tbj02EigyoDaicho.APLRIEKIGAKU
                ,Tbj02EigyoDaicho.MEDIAHARAI
                ,Tbj02EigyoDaicho.MEDIAMARGINRITSU
                ,Tbj02EigyoDaicho.MEDIAMARGINGAKU
                ,Tbj02EigyoDaicho.MEDIAGENKA
                ,Tbj02EigyoDaicho.TORIRIEKI
                ,Tbj02EigyoDaicho.RIEKIHAIBUN
                ,Tbj02EigyoDaicho.NAIKINRIEKI
                ,Tbj02EigyoDaicho.FURIKAERIEKI
                ,Tbj02EigyoDaicho.EIGYOYOIN
                ,Tbj02EigyoDaicho.FURIKAERIEKI2
                ,Tbj02EigyoDaicho.TVTMEDIATANKA
                ,Tbj02EigyoDaicho.TVTHMTANKA
                ,Tbj02EigyoDaicho.COLORFEE
                ,Tbj02EigyoDaicho.DESIGNATIONFEE
                ,Tbj02EigyoDaicho.DOUBLEFEE
                ,Tbj02EigyoDaicho.RECLASSIFICATIONFEE
                ,Tbj02EigyoDaicho.SPACEFEE
                ,Tbj02EigyoDaicho.SPLITRUNFEE
                ,Tbj02EigyoDaicho.REQUESTDESTINATION
                ,Tbj02EigyoDaicho.BRDDATE
                ,Tbj02EigyoDaicho.BIKO
                ,Tbj02EigyoDaicho.SEIKYUFLG
                ,Tbj02EigyoDaicho.CPDATE
                ,Tbj02EigyoDaicho.BRDSEC
                ,Tbj02EigyoDaicho.FILEOUTFLG
                ,Tbj02EigyoDaicho.APPEARANCEDATE
                ,Tbj02EigyoDaicho.SORTNO
                ,Tbj02EigyoDaicho.CRTDATE
                ,Tbj02EigyoDaicho.CRTNM
                ,Tbj02EigyoDaicho.CRTAPL
                ,Tbj02EigyoDaicho.CRTID
                ,Tbj02EigyoDaicho.UPDDATE
                ,Tbj02EigyoDaicho.UPDNM
                ,Tbj02EigyoDaicho.UPDAPL
                ,Tbj02EigyoDaicho.UPDID
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getExecString() {
        if (_execsqlmode.equals(ExecSqlMode.UPD)) {
            return getUpdAccountBook();
        }
        return null;
    }

    /**
     * 対象の営業作業台帳を更新します
     *
     * @return 削除SQL文
     */
    public String getUpdAccountBook() {
        StringBuffer sql = new StringBuffer();

        sql.append(" UPDATE ");
        sql.append(" " + Tbj02EigyoDaicho.TBNAME + " ");
        sql.append(" SET ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAPLANNO + " = " + _vo.getMEDIAPLANNO() +", ");
        sql.append(" " + Tbj02EigyoDaicho.IMPKEY + " = '" + _vo.getIMPKEY() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.SEIKYUYM + " = " + getDBModelInterface().ConvertToDBString(_vo.getSEIKYUYM()) + ", ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIACD + " = '" + _vo.getMEDIACD() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIASCD + " = '" + _vo.getMEDIASCD() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIASNM + " = '" + _vo.getMEDIASNM() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.KEIRETSUCD + " = '" + _vo.getKEIRETSUCD() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.DCARCD + " = '" +_vo.getDCARCD() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.HIYOUNO + " = '" + _vo.getHIYOUNO() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.KIKAKUNO + " = '" + _vo.getKIKAKUNO() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.CAMPAIGN + " = '" + _vo.getCAMPAIGN() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.NAIYOHIMOKU + " = '" + _vo.getNAIYOHIMOKU() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.SPACE + " ='" + _vo.getSPACE() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.NPDIVISION + " ='" + _vo.getNPDIVISION() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.PUBLISHVER + " ='" + _vo.getPUBLISHVER() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.SYMBOLDIVISION + " ='" + _vo.getSYMBOLDIVISION() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.POSTEDSURFACE + " ='" + _vo.getPOSTEDSURFACE() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.UNIT + " ='" + _vo.getUNIT() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.CONTRACTDIVISION + " ='" + _vo.getCONTRACTDIVISION() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.KIKANFROM + " = " + getDBModelInterface().ConvertToDBString(_vo.getKIKANFROM()) + ", ");
        sql.append(" " + Tbj02EigyoDaicho.KIKANTO + " = " + getDBModelInterface().ConvertToDBString(_vo.getKIKANTO()) + ", ");
        sql.append(" " + Tbj02EigyoDaicho.GENKAFLG + " = '" + _vo.getGENKAFLG() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.GROSS + " = " +_vo.getGROSS() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.DNEBIKIRITSU + " = " +_vo.getDNEBIKIRITSU() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.DNEBIKIGAKU + " = " + _vo.getDNEBIKIGAKU() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.HMCOST + " = " + _vo.getHMCOST() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.APLRIEKIRITSU + " = " + _vo.getAPLRIEKIRITSU() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.APLRIEKIGAKU + " = " + _vo.getAPLRIEKIGAKU() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAHARAI + " = " + _vo.getMEDIAHARAI() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAMARGINRITSU + " = " + _vo.getMEDIAMARGINRITSU() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAMARGINGAKU + " = " + _vo.getMEDIAMARGINGAKU() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAGENKA + " = " + _vo.getMEDIAGENKA() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.TORIRIEKI + " = " + _vo.getTORIRIEKI() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.RIEKIHAIBUN + " = " + _vo.getRIEKIHAIBUN() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.NAIKINRIEKI + " = " + _vo.getNAIKINRIEKI() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.FURIKAERIEKI + " = " + _vo.getFURIKAERIEKI() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.EIGYOYOIN + " = " + _vo.getEIGYOYOIN() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.FURIKAERIEKI2 + " = " + _vo.getFURIKAERIEKI2() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.TVTMEDIATANKA + " = " + _vo.getTVTMEDIATANKA() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.TVTHMTANKA + " = " + _vo.getTVTHMTANKA() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.COLORFEE + " = " + _vo.getCOLORFEE() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.DESIGNATIONFEE + " = " + _vo.getDESIGNATIONFEE() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.DOUBLEFEE + " = " + _vo.getDOUBLEFEE() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.RECLASSIFICATIONFEE + " = " + _vo.getRECLASSIFICATIONFEE() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.SPACEFEE + " = " + _vo.getSPACEFEE() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.SPLITRUNFEE + " = " + _vo.getSPLITRUNFEE() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.REQUESTDESTINATION + " = '" + _vo.getREQUESTDESTINATION() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.BRDDATE + " = '" + _vo.getBRDDATE() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.BRDSEC + " = " + _vo.getBRDSEC() + ", ");
        sql.append(" " + Tbj02EigyoDaicho.BIKO + " = '" + _vo.getBIKO() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.UPDNM + " = '" + _vo.getUPDNM() +"', ");
        sql.append(" " + Tbj02EigyoDaicho.CPDATE + " = '" + _vo.getCPDATE() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.SEIKYUFLG + " = '" + _vo.getSEIKYUFLG() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.FILEOUTFLG + " = '" + _vo.getFILEOUTFLG() + "', ");
        if (_vo.getAPPEARANCEDATE() != null) {
            sql.append(" " + Tbj02EigyoDaicho.APPEARANCEDATE + " = " + getDBModelInterface().ConvertToDBString(_vo.getAPPEARANCEDATE()) + ", ");
        }
        else
        {
            sql.append(" " + Tbj02EigyoDaicho.APPEARANCEDATE + " = NULL, ");
        }

        if (_vo.getSORTNO() != null) {
            sql.append(" " + Tbj02EigyoDaicho.SORTNO + " = " + _vo.getSORTNO() + ", ");
        }
        else
        {
            sql.append(" " + Tbj02EigyoDaicho.SORTNO + " = NULL, ");
        }

        sql.append(" " + Tbj02EigyoDaicho.UPDAPL + " = '" + _vo.getUPDAPL() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.UPDID + " = '" + _vo.getUPDID() + "', ");
        sql.append(" " + Tbj02EigyoDaicho.UPDDATE + " = SYSDATE ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAPLANNO + " = "  + _updMediaPlan + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.DAICHONO + " = " + _vo.getDAICHONO() + " ");

        return sql.toString();
    }

    /**
     * 営業作業台帳の削除を行います
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void delAccounBook(
            Tbj02EigyoDaichoVO vo) throws HAMException {
        super.setModel(vo);
        try {
            _sqlmode = SqlMode.DEL;

            if (!super.remove())
            {
                throw new HAMException("削除エラー","BJ-E0032");
            }

        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0032");
        }
    }

    /**
     * 営業作業台帳一覧の登録を行います.
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void insAccounBook(
            Tbj02EigyoDaichoVO vo) throws HAMException {

        super.setModel(vo);
        try {
            _sqlmode = SqlMode.INS;

            if (!super.insert()) {
                throw new HAMException("登録エラー", "BJ-E0032");
            }
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0032");
        }

    }
    /**
     * 営業作業台帳の更新を行います.
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void updAccounBook(
            Tbj02EigyoDaichoVO vo,BigDecimal updMediaPlan) throws HAMException {
        try {
            _sqlmode = SqlMode.UPD;
            _execsqlmode = ExecSqlMode.UPD;
            _vo = vo;
            _updMediaPlan = updMediaPlan;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0032");
        }
    }

}
