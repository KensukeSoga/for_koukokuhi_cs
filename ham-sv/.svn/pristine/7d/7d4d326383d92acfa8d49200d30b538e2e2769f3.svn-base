package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

/**
 * <P>
 * 車種マスタ取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/03/27 T.Hadate)<BR>
 * </P>
 *
 * @author Takahiro Hadate
 */
public class FindCarListDAO extends AbstractRdbDao {

    /** データ検索条件 */
    private FindCarListCondition _cond;

    /**
     * デフォルトコンストラクタ
     */
    public FindCarListDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * テーブル列名を取得する
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{
                Mbj05Car.DCARCD,
                Mbj05Car.CARNM,
                Mbj05Car.SORTNO,
                Mbj11CarSec.AUTHORITY
        };
    }

    /**
     * テーブル列名を取得する
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        return createSql();
    }

    /**
     * SQLを作成する.
     *
     * @return SQL
     */
    private String createSql() {

        StringBuilder sb = new StringBuilder();

        sb.append("SELECT");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sb.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sb.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sb.append("FROM ");
        sb.append(" "+ Mbj05Car.TBNAME + ", ");
        sb.append(" "+ Mbj11CarSec.TBNAME + " ");
        sb.append("WHERE ");
        sb.append(Mbj11CarSec.DCARCD + " = " +  Mbj05Car.DCARCD + " AND ");
        sb.append(Mbj11CarSec.SECTYPE + " = '" + _cond.get_secType() + "' AND ");
        sb.append(Mbj05Car.DISPSTS + " = '1' AND ");
        sb.append(Mbj11CarSec.AUTHORITY + " > 0 AND ");
        sb.append(Mbj11CarSec.HAMID + " = '" + _cond.get_hamid() + "' ");
        sb.append("ORDER BY " + Mbj05Car.SORTNO);

        return sb.toString();
    }

    /**
     * 車種一覧の検索を行う.
     *
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<CarListVO> findCarList(FindCarListCondition cond) throws HAMException {

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

                vo.setDCARCD((String)result.get(Mbj05Car.DCARCD.toUpperCase()));
                vo.setCARNM((String)result.get(Mbj05Car.CARNM.toUpperCase()));
                vo.setSORTNO((BigDecimal)result.get(Mbj05Car.SORTNO.toUpperCase()));
                vo.setAUTHORITY((String)result.get(Mbj11CarSec.AUTHORITY.toUpperCase()));

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }

        return list;
    }

}
