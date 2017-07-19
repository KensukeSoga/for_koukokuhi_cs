package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 営業作業台帳DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj02EigyoDaichoDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj02EigyoDaichoCondition _condition = null;
    private String _mediaPlanNo;
    private String _seikyuYM;
    private String _daichoNo;
    private enum SqlMode{ FIND, MAX, BYMEDIAPLANNO, LAST, BYDAICHONO, SUM, SORTNO};
    private SqlMode _sqlMode = SqlMode.FIND;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj02EigyoDaichoDAO() {
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
                Tbj02EigyoDaicho.MEDIAPLANNO
                ,Tbj02EigyoDaicho.DAICHONO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj02EigyoDaicho.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj02EigyoDaicho.CRTDATE
                ,Tbj02EigyoDaicho.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj02EigyoDaicho.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
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
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo) {
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
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        String sql ="";

        if (_sqlMode.equals(SqlMode.MAX)) {
            sql =getMaxDaichoNoSQLByCondition();
        } else if (_sqlMode.equals(SqlMode.BYMEDIAPLANNO)) {
            sql = getEigyoDaichoByMediaPlanNo();
        } else if (_sqlMode.equals(SqlMode.LAST)) {
            sql = getLastUpdateDaicho();
        } else if (_sqlMode.equals(SqlMode.BYDAICHONO)) {
            sql = getEigyoDaichoByDaichoNo();
        } else if (_sqlMode.equals(SqlMode.SUM)) {
            sql = getEigyoDaichoFeeSUM();
        } else if (_sqlMode.equals(SqlMode.SORTNO)) {
            sql = getMaxSortNo();
        } else {
            sql = getSelectSQLTbj02EigyoDaichoVO();
        }

        return sql;
    }

    /**
     * SELECT SQL(Tbj02EigyoDaichoVO)
     */
    private String getSelectSQLTbj02EigyoDaichoVO() {

        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";
        StringBuffer orderSql = new StringBuffer();

        //*******************************************
        //load()、find()で使用されるSELECT + FROM句のSQL
        //*******************************************
        selectSql.append(" SELECT");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }

        selectSql.append(" FROM");
        selectSql.append(" " + getTableName());

        if (_condition != null) {

            Tbj02EigyoDaichoVO vo = new Tbj02EigyoDaichoVO();

            vo.setMEDIAPLANNO(_condition.getMediaplanno());
            vo.setDAICHONO(_condition.getDaichono());
            vo.setIMPKEY(_condition.getImpkey());
            vo.setSEIKYUYM(_condition.getSeikyuym());
            vo.setMEDIACD(_condition.getMediacd());
            vo.setMEDIASCD(_condition.getMediascd());
            vo.setMEDIASNM(_condition.getMediasnm());
            vo.setKEIRETSUCD(_condition.getKeiretsucd());
            vo.setDCARCD(_condition.getDcarcd());
            vo.setHIYOUNO(_condition.getHiyouno());
            vo.setKIKAKUNO(_condition.getKikakuno());
            vo.setCAMPAIGN(_condition.getCampaign());
            vo.setNAIYOHIMOKU(_condition.getNaiyohimoku());
            vo.setSPACE(_condition.getSpace());
            vo.setNPDIVISION(_condition.getNpdivision());
            vo.setPUBLISHVER(_condition.getPublishver());
            vo.setSYMBOLDIVISION(_condition.getSymboldivision());
            vo.setPOSTEDSURFACE(_condition.getPostedsurface());
            vo.setUNIT(_condition.getUnit());
            vo.setCONTRACTDIVISION(_condition.getContractdivision());
            vo.setKIKANFROM(_condition.getKikanfrom());
            vo.setKIKANTO(_condition.getKikanto());
            vo.setGENKAFLG(_condition.getGenkaflg());
            vo.setGROSS(_condition.getGross());
            vo.setDNEBIKIRITSU(_condition.getDnebikiritsu());
            vo.setDNEBIKIGAKU(_condition.getDnebikigaku());
            vo.setHMCOST(_condition.getHmcost());
            vo.setAPLRIEKIRITSU(_condition.getAplriekiritsu());
            vo.setAPLRIEKIGAKU(_condition.getAplriekigaku());
            vo.setMEDIAHARAI(_condition.getMediaharai());
            vo.setMEDIAMARGINRITSU(_condition.getMediamarginritsu());
            vo.setMEDIAMARGINGAKU(_condition.getMediamargingaku());
            vo.setMEDIAGENKA(_condition.getMediagenka());
            vo.setTORIRIEKI(_condition.getToririeki());
            vo.setRIEKIHAIBUN(_condition.getRiekihaibun());
            vo.setNAIKINRIEKI(_condition.getNaikinrieki());
            vo.setFURIKAERIEKI(_condition.getFurikaerieki());
            vo.setEIGYOYOIN(_condition.getEigyoyoin());
            vo.setFURIKAERIEKI2(_condition.getFurikaerieki2());
            vo.setTVTMEDIATANKA(_condition.getTvtmediatanka());
            vo.setTVTHMTANKA(_condition.getTvthmtanka());
            vo.setCOLORFEE(_condition.getColorfee());
            vo.setDESIGNATIONFEE(_condition.getDesignationfee());
            vo.setDOUBLEFEE(_condition.getDoublefee());
            vo.setRECLASSIFICATIONFEE(_condition.getReclassificationfee());
            vo.setSPACEFEE(_condition.getSpacefee());
            vo.setSPLITRUNFEE(_condition.getSplitrunfee());
            vo.setREQUESTDESTINATION(_condition.getRequestdestination());
            vo.setBRDDATE(_condition.getBrddate());
            vo.setBIKO(_condition.getBiko());
            vo.setSEIKYUFLG(_condition.getSeikyuflg());
            vo.setCPDATE(_condition.getCpdate());
            vo.setBRDSEC(_condition.getBrdsec());
            vo.setFILEOUTFLG(_condition.getFileoutflg());
            vo.setAPPEARANCEDATE(_condition.getAppearancedate());
            vo.setSORTNO(_condition.getSortno());
            vo.setCRTDATE(_condition.getCrtdate());
            vo.setCRTNM(_condition.getCrtnm());
            vo.setCRTAPL(_condition.getCrtapl());
            vo.setCRTID(_condition.getCrtid());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());

            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Tbj02EigyoDaicho.SORTNO + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    }

    /**営業作業台帳MAX値取得*/
    private String getMaxDaichoNoSQLByCondition() {

         StringBuffer sql = new StringBuffer();

         sql.append("SELECT ");
         sql.append(" NVL(MAX(" + Tbj02EigyoDaicho.MEDIAPLANNO + "),0)AS " +Tbj02EigyoDaicho.MEDIAPLANNO+"," );
         sql.append(" TO_CHAR(NVL(MAX(TO_NUMBER(" + Tbj02EigyoDaicho.DAICHONO + ")),0)) AS " + Tbj02EigyoDaicho.DAICHONO);
         sql.append(" FROM ");
         sql.append(" " + getTableName() + " ");

         return sql.toString();
    }

    /**
     * 媒体管理Noによる営業作業台帳データ検索
     * @return SQL文
     */
    private String getEigyoDaichoByMediaPlanNo() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append(" * ");
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAPLANNO + " = " + _mediaPlanNo + " ");


        return sql.toString();
    }

    private String getLastUpdateDaicho()
    {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append(" " +Tbj02EigyoDaicho.UPDDATE + ", ");
        sql.append(" " +Tbj02EigyoDaicho.UPDNM + " ");
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" TO_CHAR(" +Tbj02EigyoDaicho.SEIKYUYM + ",'YYYY/MM') = '" + _seikyuYM + "' ");
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj02EigyoDaicho.UPDDATE + " DESC ");

        return sql.toString();

    }

    /**
     * 台帳Noによる検索を行う
     * @return SQL文
     */
    private String getEigyoDaichoByDaichoNo() {
        StringBuffer sql = new StringBuffer();
        sql.append(" SELECT");

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
        sql.append(" " + Tbj02EigyoDaicho.DAICHONO + " ='" + _daichoNo + "' ");
        return sql.toString();
    }

    /**
     * 営業作業台帳の料金合計を取得
     * @return SQL文
     */
    private String getEigyoDaichoFeeSUM() {
        StringBuffer sql = new StringBuffer();
        sql.append(" SELECT ");
        sql.append(" NVL(SUM(" + Tbj02EigyoDaicho.GROSS + "),0) AS " + Tbj02EigyoDaicho.GROSS + ", ");
        sql.append(" NVL(SUM(" + Tbj02EigyoDaicho.HMCOST + "),0) AS " +Tbj02EigyoDaicho.HMCOST + " ");
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAPLANNO + " ='" + _mediaPlanNo + "' ");

        return sql.toString();
    }

    /**
     * 営業作業台帳のソート順の最大値を取得
     * @return SQL文
     */
    private String getMaxSortNo() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        sql.append("NVL(MAX(" + Tbj02EigyoDaicho.SORTNO + "), 0) AS " + Tbj02EigyoDaicho.SORTNO);
        sql.append(" FROM ");
        sql.append(getTableName());
        sql.append(" WHERE ");
        sql.append(Tbj02EigyoDaicho.KIKANFROM + " >= " + getDBModelInterface().ConvertToDBString(_condition.getKikanfrom()));
        sql.append(" AND ");
        sql.append(Tbj02EigyoDaicho.KIKANTO + " <= " + getDBModelInterface().ConvertToDBString(_condition.getKikanto()));

        return sql.toString();
    }

    /**
     * InsertVO
     * @param vo データ
     * @throws HAMException
     */
    public void insertVO(Tbj02EigyoDaichoVO vo) throws HAMException {

        // パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);

        try {
            if (!super.insert()) {
                throw new HAMException("登録エラー", "BJ-E0002");
            }
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * UpdateVO
     * @param vo データ
     * @throws HAMException
     */
    public void updateVO(Tbj02EigyoDaichoVO vo) throws HAMException {

        // パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);

        try {
            if (!super.update()) {
                throw new HAMException("更新エラー", "BJ-E0003");
            }
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * DeleteVO
     * @param vo データ
     * @throws HAMException
     */
    public void deleteVO(Tbj02EigyoDaichoVO vo) throws HAMException {

        // パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);

        try {
            if (!super.remove()) {
                throw new HAMException("削除エラー", "BJ-E0004");
            }
        } catch(ConcurrentUpdateException e) {
            //処理件数「0」の場合

            //正常とする(削除レコードなし)
            return;
        } catch(UpdateFailureException e) {
            // 処理件数「2以上」の場合

            //正常とする
            return;
        } catch(UserException e) {
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
    public List<Tbj02EigyoDaichoVO> selectVO(Tbj02EigyoDaichoCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj02EigyoDaichoVO());
        _condition = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 作業台帳NO最大値取得
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj02EigyoDaichoVO> selectMaxDaichoNo() throws HAMException {

        super.setModel(new Tbj02EigyoDaichoVO());

        try {
            _sqlMode = SqlMode.MAX;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 最終更新情報取得
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj02EigyoDaichoVO> FindLastUpdate(String seikyuYM) throws HAMException {

        super.setModel(new Tbj02EigyoDaichoVO());

        try {
            _seikyuYM = seikyuYM;
            _sqlMode = SqlMode.LAST;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 媒体管理Noによる検索
     * @param 媒体管理No
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj02EigyoDaichoVO> FindEigyoDaichoByMediaPlanNo(String mediaPlanNo) throws HAMException {

        super.setModel(new Tbj02EigyoDaichoVO());

        try {
            _sqlMode = SqlMode.BYMEDIAPLANNO;
            _mediaPlanNo = mediaPlanNo;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 台帳Noによる検索
     * @param 台帳No
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj02EigyoDaichoVO> FindEigyoDaichoByDaichoNo(String daichoNo) throws HAMException {

        super.setModel(new Tbj02EigyoDaichoVO());

        try {
            _sqlMode = SqlMode.BYDAICHONO;
            _daichoNo = daichoNo;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 媒体状況管理NOに対する営業作業台帳の料金合計を取得
     * @param mediaPlanNo 媒体状況管理No
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj02EigyoDaichoVO> FindEigyoDaichoFeeSUM(String mediaPlanNo) throws HAMException {

        super.setModel(new Tbj02EigyoDaichoVO());

        try {
            _sqlMode = SqlMode.SUM;
            _mediaPlanNo = mediaPlanNo;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * ソート順の最大値を取得
     * @param condition 取得条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj02EigyoDaichoVO> FindMaxSortNo(Tbj02EigyoDaichoCondition condition) throws HAMException {

        super.setModel(new Tbj02EigyoDaichoVO());

        try {
            _sqlMode = SqlMode.SORTNO;
            _condition = condition;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
