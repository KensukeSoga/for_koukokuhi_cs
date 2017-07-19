package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Tbj12Campaign;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

/**
 *
 * <P>
 * キャンペーン一覧の情報取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class FindCarListDAO extends AbstractRdbDao {

    /** データ検索条件 */
    private FindCampaignListCondition _cond;

    /**
     * デフォルトコンストラクタ
     */
    public FindCarListDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを返します
     *
     * @return String[] プライマリキー
     */
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return null;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[]{
                Mbj05Car.KEIRETSUCD,
                Mbj05Car.DCARCD,
                Mbj05Car.CARNM,
                Mbj05Car.SORTNO,
                Mbj11CarSec.DCARCD,
                Mbj11CarSec.AUTHORITY
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        return getCarList();
    }

    /**
     *作成済み 車種一覧取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getCarList() {

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
        sql.append(" "+ Mbj05Car.TBNAME + ", ");
        sql.append(" "+ Mbj11CarSec.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" "+ Mbj11CarSec.SECTYPE+ " = '0' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj05Car.DISPSTS+ " = '1' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj11CarSec.DCARCD + " = " + Mbj05Car.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj11CarSec.HAMID + " = '" + _cond.getHamid() + "' ");
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.AUTHORITY + " <> '0'" );
        sql.append(" AND ");
        sql.append(" "+ Mbj05Car.DCARCD + " IN ( ");
        sql.append(" SELECT DISTINCT");
        sql.append(" "+ Tbj12Campaign.DCARCD + " ");
        sql.append(" FROM ");
        sql.append(" "+ Tbj12Campaign.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" "+ Tbj12Campaign.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" ) ");
        sql.append(" ORDER BY ");
        sql.append("  "+ Mbj05Car.SORTNO + "  ");
        sql.append(" ,"+ Mbj05Car.DCARCD + "  ");

        return sql.toString();
    }

    /**
     * 作成済み車種一覧の検索を行います
     *
     * @return 車種一覧VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<CarListVO> findCarList(FindCampaignListCondition cond) throws HAMException {

        super.setModel(new CarListVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BD-E0002");
        }
    }

    /**
     * Modelの生成を行う<br>
     * 検索結果のVOのKEYが大文字のため変換処理を行う<br>
     * AbstractRdbDaoのcreateFindedModelInstancesをオーバーライド<br>
     *
     * @param hashList
     *            List 検索結果
     * @return List<FindJissiNoCntCondVO> 変換後の検索結果
     */
    @Override
    protected List<CarListVO> createFindedModelInstances(List hashList) {

        List<CarListVO> list = new ArrayList<CarListVO>();

        if (getModel() instanceof CarListVO) {
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                CarListVO vo = new CarListVO();
                vo.setKEIRETSUCD((String)result.get(Mbj05Car.KEIRETSUCD.toUpperCase()));
                vo.setDCARCD((String)result.get(Mbj05Car.DCARCD.toUpperCase()));
                vo.setCARNM((String)result.get(Mbj05Car.CARNM.toUpperCase()));
                vo.setSORTNO((BigDecimal)result.get(Mbj05Car.SORTNO.toUpperCase()));
                vo.setAUTHORITY((String)result.get(Mbj11CarSec.AUTHORITY.toUpperCase()));

                // 検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }

        return list;
    }

}
