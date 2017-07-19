package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj01MediaPlan;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.tbl.Tbj12Campaign;
import jp.co.isid.ham.integ.tbl.Tbj23LogEigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.DummyNull;
import jp.co.isid.nj.model.ModelUtils;
/**
 * <P>
 * 営業作業台帳変更ログDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class FindAccountBookLogDAO extends AbstractRdbDao {

    /** 検索条件 */
    private String _daichoNo = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindAccountBookLogDAO() {
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
                Tbj23LogEigyoDaicho.MEDIAPLANNO
                ,Tbj23LogEigyoDaicho.DAICHONO
                ,Tbj23LogEigyoDaicho.HISTORYNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj23LogEigyoDaicho.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj23LogEigyoDaicho.CRTDATE
                ,Tbj23LogEigyoDaicho.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj23LogEigyoDaicho.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj23LogEigyoDaicho.MEDIAPLANNO
                ,Tbj23LogEigyoDaicho.DAICHONO
                ,Tbj23LogEigyoDaicho.HISTORYNO
                ,Tbj23LogEigyoDaicho.HISTORYKBN
                ,Tbj23LogEigyoDaicho.IMPKEY
                ,Tbj23LogEigyoDaicho.SEIKYUYM
                ,Tbj23LogEigyoDaicho.MEDIACD
                ,Tbj23LogEigyoDaicho.MEDIASCD
                ,Tbj23LogEigyoDaicho.MEDIASNM
                ,Tbj23LogEigyoDaicho.KEIRETSUCD
                ,Tbj23LogEigyoDaicho.DCARCD
                ,Tbj23LogEigyoDaicho.HIYOUNO
                ,Tbj23LogEigyoDaicho.KIKAKUNO
                ,Tbj23LogEigyoDaicho.CAMPAIGN
                ,Tbj23LogEigyoDaicho.NAIYOHIMOKU
                ,Tbj23LogEigyoDaicho.SPACE
                ,Tbj23LogEigyoDaicho.NPDIVISION
                ,Tbj23LogEigyoDaicho.PUBLISHVER
                ,Tbj23LogEigyoDaicho.SYMBOLDIVISION
                ,Tbj23LogEigyoDaicho.POSTEDSURFACE
                ,Tbj23LogEigyoDaicho.UNIT
                ,Tbj23LogEigyoDaicho.CONTRACTDIVISION
                ,Tbj23LogEigyoDaicho.KIKANFROM
                ,Tbj23LogEigyoDaicho.KIKANTO
                ,Tbj23LogEigyoDaicho.GENKAFLG
                ,Tbj23LogEigyoDaicho.GROSS
                ,Tbj23LogEigyoDaicho.DNEBIKIRITSU
                ,Tbj23LogEigyoDaicho.DNEBIKIGAKU
                ,Tbj23LogEigyoDaicho.HMCOST
                ,Tbj23LogEigyoDaicho.APLRIEKIRITSU
                ,Tbj23LogEigyoDaicho.APLRIEKIGAKU
                ,Tbj23LogEigyoDaicho.MEDIAHARAI
                ,Tbj23LogEigyoDaicho.MEDIAMARGINRITSU
                ,Tbj23LogEigyoDaicho.MEDIAMARGINGAKU
                ,Tbj23LogEigyoDaicho.MEDIAGENKA
                ,Tbj23LogEigyoDaicho.TORIRIEKI
                ,Tbj23LogEigyoDaicho.RIEKIHAIBUN
                ,Tbj23LogEigyoDaicho.NAIKINRIEKI
                ,Tbj23LogEigyoDaicho.FURIKAERIEKI
                ,Tbj23LogEigyoDaicho.EIGYOYOIN
                ,Tbj23LogEigyoDaicho.FURIKAERIEKI2
                ,Tbj23LogEigyoDaicho.TVTMEDIATANKA
                ,Tbj23LogEigyoDaicho.TVTHMTANKA
                ,Tbj23LogEigyoDaicho.COLORFEE
                ,Tbj23LogEigyoDaicho.DESIGNATIONFEE
                ,Tbj23LogEigyoDaicho.DOUBLEFEE
                ,Tbj23LogEigyoDaicho.RECLASSIFICATIONFEE
                ,Tbj23LogEigyoDaicho.SPACEFEE
                ,Tbj23LogEigyoDaicho.SPLITRUNFEE
                ,Tbj23LogEigyoDaicho.REQUESTDESTINATION
                ,Tbj23LogEigyoDaicho.BRDDATE
                ,Tbj23LogEigyoDaicho.BIKO
                ,Tbj23LogEigyoDaicho.SEIKYUFLG
                ,Tbj23LogEigyoDaicho.CPDATE
                ,Tbj23LogEigyoDaicho.BRDSEC
                ,Tbj23LogEigyoDaicho.FILEOUTFLG
                ,Tbj23LogEigyoDaicho.APPEARANCEDATE
                ,Tbj23LogEigyoDaicho.SORTNO
                ,Tbj23LogEigyoDaicho.CRTDATE
                ,Tbj23LogEigyoDaicho.CRTNM
                ,Tbj23LogEigyoDaicho.CRTAPL
                ,Tbj23LogEigyoDaicho.CRTID
                ,Tbj23LogEigyoDaicho.UPDDATE
                ,Tbj23LogEigyoDaicho.UPDNM
                ,Tbj23LogEigyoDaicho.UPDAPL
                ,Tbj23LogEigyoDaicho.UPDID
                ,Mbj05Car.CARNM
                ,Mbj03Media.MEDIANM
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        return getLogEigyoDaicho();
    }

    /** 対象の営業台帳履歴取得SQL */
    private String getLogEigyoDaicho() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        //キャンペーンコード：キャンペーン名で取得
        sql.append(" " + Tbj12Campaign.CAMPCD + " || '：' || " + Tbj12Campaign.CAMPNM + " AS DISPCAMPCD, ");
        //媒体状況管理No：件名で取得
        sql.append(" " + Tbj01MediaPlan.MEDIAPLANNO + " || '：' || " + Tbj01MediaPlan.KENMEI + " AS DISPMEDIAPLANNO, ");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + ", ");
        sql.append(" " + Tbj01MediaPlan.TBNAME + ",");
        sql.append(" " + Tbj12Campaign.TBNAME + ",");
        sql.append(" " + Mbj03Media.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj23LogEigyoDaicho.MEDIAPLANNO + " = " + Tbj01MediaPlan.MEDIAPLANNO + "(+) AND");
        sql.append(" " + Tbj01MediaPlan.CAMPCD + " = " + Tbj12Campaign.CAMPCD + "(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj23LogEigyoDaicho.MEDIACD + " = " + Mbj03Media.MEDIACD + "(+) AND");
        sql.append(" " + Tbj23LogEigyoDaicho.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND" );
        sql.append(" " + Tbj23LogEigyoDaicho.DAICHONO + " = " + _daichoNo + " ");
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj23LogEigyoDaicho.HISTORYNO + " ");

        return sql.toString();
    }

    /**
     * 営業作業台帳履歴取得
     * @param 媒体管理No
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindAccountBookLogVO> FindEigyoDaichoHistory(String daichoNo) throws HAMException {

        super.setModel(new FindAccountBookLogVO());

        try {
            _daichoNo = daichoNo;
            return super.find();
        }
        catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * Modelの生成を行う<br>
     * 検索結果のVOのKEYが大文字のため変換処理を行う<br>
     * AbstractRdbDaoのcreateFindedModelInstancesをオーバーライド<br>
     *
     * @param hashList
     *            List 検索結果
     * @return List<FindAuthorityAccountBookVO> 変換後の検索結果
     */
    @Override
    protected List<FindAccountBookLogVO> createFindedModelInstances(List hashList) {

        List<FindAccountBookLogVO> list = new ArrayList<FindAccountBookLogVO>();

        if (getModel() instanceof FindAccountBookLogVO) {

            for (int i = 0; i < hashList.size(); i++) {

                Map result = (Map) hashList.get(i);
                FindAccountBookLogVO vo = new FindAccountBookLogVO();

                vo.setDISPCAMPCD((String)result.get("DISPCAMPCD"));
                vo.setDISPMEDIAPLANNO((String)result.get("DISPMEDIAPLANNO"));
                vo.setMEDIAPLANNO((BigDecimal)result.get(Tbj23LogEigyoDaicho.MEDIAPLANNO.toUpperCase()));
                vo.setDAICHONO((String)result.get(Tbj23LogEigyoDaicho.DAICHONO.toUpperCase()));
                vo.setIMPKEY((String)result.get(Tbj23LogEigyoDaicho.IMPKEY.toUpperCase()));
                vo.setSEIKYUYM((Date)result.get(Tbj23LogEigyoDaicho.SEIKYUYM.toUpperCase()));
                vo.setMEDIACD((String)result.get(Tbj23LogEigyoDaicho.MEDIACD.toUpperCase()));
                vo.setMEDIASCD((String)result.get(Tbj23LogEigyoDaicho.MEDIASCD.toUpperCase()));
                vo.setMEDIASNM((String)result.get(Tbj23LogEigyoDaicho.MEDIASNM.toUpperCase()));
                vo.setKEIRETSUCD((String)result.get(Tbj23LogEigyoDaicho.KEIRETSUCD.toUpperCase()));
                vo.setDCARCD((String)result.get(Tbj23LogEigyoDaicho.DCARCD.toUpperCase()));
                vo.setCARNM((String)result.get(Mbj05Car.CARNM.toUpperCase()));
                vo.setHIYOUNO((String)result.get(Tbj23LogEigyoDaicho.HIYOUNO.toUpperCase()));
                vo.setKIKAKUNO((String)result.get(Tbj23LogEigyoDaicho.KIKAKUNO.toUpperCase()));
                vo.setCAMPAIGN((String)result.get(Tbj23LogEigyoDaicho.CAMPAIGN.toUpperCase()));
                vo.setNAIYOHIMOKU((String)result.get(Tbj23LogEigyoDaicho.NAIYOHIMOKU.toUpperCase()));
                vo.setSPACE((String)result.get(Tbj23LogEigyoDaicho.SPACE.toUpperCase()));
                vo.setNPDIVISION((String)result.get(Tbj23LogEigyoDaicho.NPDIVISION.toUpperCase()));
                vo.setPUBLISHVER((String)result.get(Tbj23LogEigyoDaicho.PUBLISHVER.toUpperCase()));
                vo.setSYMBOLDIVISION((String)result.get(Tbj23LogEigyoDaicho.SYMBOLDIVISION.toUpperCase()));
                vo.setPOSTEDSURFACE((String)result.get(Tbj23LogEigyoDaicho.POSTEDSURFACE.toUpperCase()));
                vo.setUNIT((String)result.get(Tbj23LogEigyoDaicho.UNIT.toUpperCase()));
                vo.setCONTRACTDIVISION((String)result.get(Tbj23LogEigyoDaicho.CONTRACTDIVISION.toUpperCase()));
                vo.setKIKANFROM((Date)result.get(Tbj23LogEigyoDaicho.KIKANFROM.toUpperCase()));
                vo.setKIKANTO((Date)result.get(Tbj23LogEigyoDaicho.KIKANTO.toUpperCase()));
                vo.setGENKAFLG((String)result.get(Tbj23LogEigyoDaicho.GENKAFLG.toUpperCase()));
                vo.setGROSS((BigDecimal)result.get(Tbj23LogEigyoDaicho.GROSS.toUpperCase()));
                vo.setDNEBIKIRITSU((BigDecimal)result.get(Tbj23LogEigyoDaicho.DNEBIKIRITSU.toUpperCase()));
                vo.setDNEBIKIGAKU((BigDecimal)result.get(Tbj23LogEigyoDaicho.DNEBIKIGAKU.toUpperCase()));
                vo.setHMCOST((BigDecimal)result.get(Tbj23LogEigyoDaicho.HMCOST.toUpperCase()));
                vo.setAPLRIEKIRITSU((BigDecimal)result.get(Tbj23LogEigyoDaicho.APLRIEKIRITSU.toUpperCase()));
                vo.setAPLRIEKIGAKU((BigDecimal)result.get(Tbj23LogEigyoDaicho.APLRIEKIGAKU.toUpperCase()));
                vo.setMEDIAHARAI((BigDecimal)result.get(Tbj23LogEigyoDaicho.MEDIAHARAI.toUpperCase()));
                vo.setMEDIAMARGINRITSU((BigDecimal)result.get(Tbj23LogEigyoDaicho.MEDIAMARGINRITSU.toUpperCase()));
                vo.setMEDIAMARGINGAKU((BigDecimal)result.get(Tbj23LogEigyoDaicho.MEDIAMARGINGAKU.toUpperCase()));
                vo.setMEDIAGENKA((BigDecimal)result.get(Tbj23LogEigyoDaicho.MEDIAGENKA.toUpperCase()));
                vo.setTORIRIEKI((BigDecimal)result.get(Tbj23LogEigyoDaicho.TORIRIEKI.toUpperCase()));
                vo.setRIEKIHAIBUN((BigDecimal)result.get(Tbj23LogEigyoDaicho.RIEKIHAIBUN.toUpperCase()));
                vo.setNAIKINRIEKI((BigDecimal)result.get(Tbj23LogEigyoDaicho.NAIKINRIEKI.toUpperCase()));
                vo.setFURIKAERIEKI((BigDecimal)result.get(Tbj23LogEigyoDaicho.FURIKAERIEKI.toUpperCase()));
                vo.setEIGYOYOIN((BigDecimal)result.get(Tbj23LogEigyoDaicho.EIGYOYOIN.toUpperCase()));
                vo.setFURIKAERIEKI2((BigDecimal)result.get(Tbj23LogEigyoDaicho.FURIKAERIEKI2.toUpperCase()));
                vo.setTVTMEDIATANKA((BigDecimal)result.get(Tbj23LogEigyoDaicho.TVTMEDIATANKA.toUpperCase()));
                vo.setTVTHMTANKA((BigDecimal)result.get(Tbj23LogEigyoDaicho.TVTHMTANKA.toUpperCase()));
                vo.setCOLORFEE((BigDecimal)result.get(Tbj23LogEigyoDaicho.COLORFEE.toUpperCase()));
                vo.setDESIGNATIONFEE((BigDecimal)result.get(Tbj23LogEigyoDaicho.DESIGNATIONFEE.toUpperCase()));
                vo.setDOUBLEFEE((BigDecimal)result.get(Tbj23LogEigyoDaicho.DOUBLEFEE.toUpperCase()));
                vo.setRECLASSIFICATIONFEE((BigDecimal)result.get(Tbj23LogEigyoDaicho.RECLASSIFICATIONFEE.toUpperCase()));
                vo.setSPACEFEE((BigDecimal)result.get(Tbj23LogEigyoDaicho.SPACEFEE.toUpperCase()));
                vo.setSPLITRUNFEE((BigDecimal)result.get(Tbj23LogEigyoDaicho.SPLITRUNFEE.toUpperCase()));
                vo.setREQUESTDESTINATION((String)result.get(Tbj23LogEigyoDaicho.REQUESTDESTINATION.toUpperCase()));
                vo.setBRDDATE((String)result.get(Tbj23LogEigyoDaicho.BRDDATE.toUpperCase()));
                vo.setBIKO((String)result.get(Tbj23LogEigyoDaicho.BIKO.toUpperCase()));
                vo.setSEIKYUFLG((String)result.get(Tbj23LogEigyoDaicho.SEIKYUFLG.toUpperCase()));
                vo.setCPDATE((String)result.get(Tbj23LogEigyoDaicho.CPDATE.toUpperCase()));
                vo.setBRDSEC((BigDecimal)result.get(Tbj23LogEigyoDaicho.BRDSEC.toUpperCase()));
                vo.setFILEOUTFLG((String)result.get(Tbj23LogEigyoDaicho.FILEOUTFLG.toUpperCase()));
                vo.setFILEOUTFLG((String)result.get(Tbj02EigyoDaicho.FILEOUTFLG.toUpperCase()));
                if (!(result.get(Tbj23LogEigyoDaicho.APPEARANCEDATE.toUpperCase()) instanceof DummyNull))
                {
                    vo.setAPPEARANCEDATE((Date)result.get(Tbj23LogEigyoDaicho.APPEARANCEDATE.toUpperCase()));
                }
                vo.setSORTNO((BigDecimal)result.get(Tbj23LogEigyoDaicho.SORTNO.toUpperCase()));
                vo.setCRTDATE((Date)result.get(Tbj23LogEigyoDaicho.CRTDATE.toUpperCase()));
                vo.setCRTNM((String)result.get(Tbj23LogEigyoDaicho.CRTNM.toUpperCase()));
                vo.setCRTAPL((String)result.get(Tbj23LogEigyoDaicho.CRTAPL.toUpperCase()));
                vo.setCRTID((String)result.get(Tbj23LogEigyoDaicho.CRTID.toUpperCase()));
                vo.setUPDDATE((Date)result.get(Tbj23LogEigyoDaicho.UPDDATE.toUpperCase()));
                vo.setUPDNM((String)result.get(Tbj23LogEigyoDaicho.UPDNM.toUpperCase()));
                vo.setUPDAPL((String)result.get(Tbj23LogEigyoDaicho.UPDAPL.toUpperCase()));
                vo.setUPDID((String)result.get(Tbj23LogEigyoDaicho.UPDID.toUpperCase()));
                vo.setMEDIANM((String)result.get(Mbj03Media.MEDIANM.toUpperCase()));

                // 検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }

        return list;
    }

}
