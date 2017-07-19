package jp.co.isid.ham.media.model;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import jp.co.isid.ham.integ.tbl.Tbj01MediaPlan;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

/**
 *
 * <P>
 * キャンペーン詳細入力拒否データの情報取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/18 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class FindInputRejectionDAO extends AbstractRdbDao {


    /** データ検索条件 */
    private String _campCd;

    private final String BAITAICNT = "BAITAI_CNT";
    /**
     * デフォルトコンストラクタ
     */
    public FindInputRejectionDAO() {
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
        // new String[] {};
        return null;
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj01MediaPlan.TBNAME;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {
        return getInputRejectionDataByMediaPlan();
    }

    /**
     *キャンペーン詳細入力拒否データ.
     *
     * @return String SQL文
     */
    private String getInputRejectionDataByMediaPlan()
    {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + ", ");
        sql.append(" TO_CHAR(" + Tbj01MediaPlan.YOTEIYM+ ",'YYYY/MM') AS " + Tbj01MediaPlan.YOTEIYM + " ");
        sql.append(" FROM ");
        sql.append( " " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj01MediaPlan.CAMPCD + " ='" + _campCd + "' ");
        sql.append(" GROUP BY ");
        sql.append(" TO_CHAR(" + Tbj01MediaPlan.YOTEIYM+ ",'YYYY/MM')" + ", ");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + " ");
        sql.append(" HAVING ");
        sql.append(" COUNT(" + Tbj01MediaPlan.MEDIACD + ") > 1");
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + ", ");
        sql.append(" " + Tbj01MediaPlan.YOTEIYM + " ");

        return sql.toString();
    }


    /**
     * 媒体状況管理の入力拒否データ検索を行います
     *
     * @return 媒体状況管理入力拒否データ一覧VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<FindInputRejectionVO> findMediaPlanInputRejection(
            String campCd) throws HAMException {

        super.setModel(new FindInputRejectionVO());

        try {
            _campCd = campCd;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "E0002");
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
    protected List<FindInputRejectionVO> createFindedModelInstances(List hashList) {

        List<FindInputRejectionVO> list = new ArrayList<FindInputRejectionVO>();

        if (getModel() instanceof FindInputRejectionVO) {

            for (int i = 0; i < hashList.size(); i++) {

                Map result = (Map) hashList.get(i);
                FindInputRejectionVO vo = new FindInputRejectionVO();

                vo.setMEDIACD((String)result.get(Tbj01MediaPlan.MEDIACD.toUpperCase()));
                vo.setYOTEIYM((String)result.get(Tbj01MediaPlan.YOTEIYM.toUpperCase()));
                vo.setBAITAICNT((String)result.get(this.BAITAICNT.toUpperCase()));
                // 検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }
        return list;
    }

}