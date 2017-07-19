/**
 *
 */
package jp.co.isid.ham.media.model;

import java.math.BigDecimal;

import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.tbl.Tbj23LogEigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
*
* <P>
* TVTime取込み時の登録DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/01/22 HLC H.Watabe)<BR>
* </P>
*
* @author HLC H.Watabe
*/
public class TVTImportRegisterDAO extends AbstractSimpleRdbDao {

    private BigDecimal _mediaPlanNo = null;
    private enum SqlMode{DAICHO,LOG};
    private SqlMode _sqlmode = SqlMode.DAICHO;

    /**
     * デフォルトコンストラクタ
     */
    public TVTImportRegisterDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを返す
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
                ,Tbj02EigyoDaicho.BRDDATE
                ,Tbj02EigyoDaicho.BIKO
                ,Tbj02EigyoDaicho.SEIKYUFLG
                ,Tbj02EigyoDaicho.CPDATE
                ,Tbj02EigyoDaicho.BRDSEC
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
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return Tbj02EigyoDaicho.TBNAME;
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
        return new String[]{
            Tbj02EigyoDaicho.CRTDATE,
            Tbj02EigyoDaicho.UPDDATE
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getExecString() {
        if (_sqlmode.equals(SqlMode.DAICHO)) {
            return getDelAccountBook();
        }
        else if (_sqlmode.equals(SqlMode.LOG)) {
            return getDelAccountBookLog();
        }
        return null;

    }

    /**
     * 対象の営業作業台帳を削除します
     *
     * @return 削除SQL文
     */
    public String getDelAccountBook() {
        StringBuffer sql = new StringBuffer();

        sql.append(" DELETE ");
        sql.append(" FROM ");
        sql.append(" " + Tbj02EigyoDaicho.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAPLANNO + " ='" + _mediaPlanNo + "' ");

        return sql.toString();
    }


    public String getDelAccountBookLog() {
        StringBuffer sql = new StringBuffer();

        sql.append(" DELETE ");
        sql.append(" FROM ");
        sql.append(" " + Tbj23LogEigyoDaicho.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj23LogEigyoDaicho.MEDIAPLANNO + " ='" + _mediaPlanNo + "' ");

        return sql.toString();
    }

    /**
     * 営業作業台帳の登録を行います.
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void insAccounBook(
            Tbj02EigyoDaichoVO vo) throws HAMException {

        super.setModel(vo);
        try {

            if (!super.insert()) {
                throw new HAMException("登録エラー", "BJ-E0002");
            }
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }

    }

    /**
     * 媒体管理Noによる営業作業台帳の削除を行います
     *
     * @return
     * @throws HAMException データアクセス中にエラーが発生した場合
     */
    public void delAccountBook(BigDecimal mediaPlanNo) throws HAMException {

        try {
            _sqlmode = SqlMode.DAICHO;
            _mediaPlanNo = mediaPlanNo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * 媒体管理Noによる営業作業台帳履歴の削除を行います
     *
     * @return
     * @throws HAMException データアクセス中にエラーが発生した場合
     */
    public void delAccountBookLog(BigDecimal mediaPlanNo) throws HAMException {

        try {
            _sqlmode = SqlMode.LOG;
            _mediaPlanNo = mediaPlanNo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
