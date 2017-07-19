package jp.co.isid.ham.media.model;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
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
* キャンペーンの情報取得DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/01/22 HLC M.Tsuchiya)<BR>
* </P>
*
* @author HLC M.Tsuchiya
*/
public class FindMediaPlanCampaignDAO extends AbstractRdbDao{

    /** データ検索条件 */
    private FindMediaPlanCondition _cond;

    /**
     * デフォルトコンストラクタ
     */
    public FindMediaPlanCampaignDAO() {
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
                Tbj12Campaign.CAMPCD,
                Tbj12Campaign.CAMPNM,
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        return getMediaPlanCampaign();
    }

    /**
     *キャンペーンのSQL文を返します
     *
     * @return String SQL文
     */
    private String getMediaPlanCampaign() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(", " + Tbj12Campaign.CAMPCD + " || ' ' || "  + Tbj12Campaign.CAMPNM + " AS CODENAME ");
        sql.append(" FROM ");
        sql.append(" Tbj12Campaign ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj12Campaign.PHASE + " = '" + _cond.getPhase() +"' ");
        sql.append(" AND ");
        sql.append(" " +  Tbj12Campaign.DCARCD + " = '" + _cond.getDcarcd() +"' ");
        sql.append(" ORDER BY ");
        sql.append(" "+ Tbj12Campaign.CAMPCD + " ASC ");

        return sql.toString();
    }

    /**
     * キャンペーンの検索を行います
     *
     * @return キャンペーンVOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<FindMediaPlanCampaignVO> findMediaPlanCampaign(FindMediaPlanCondition cond) throws HAMException {

        super.setModel(new FindMediaPlanCampaignVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
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
    protected List<FindMediaPlanCampaignVO> createFindedModelInstances(List hashList) {

        List<FindMediaPlanCampaignVO> list = new ArrayList<FindMediaPlanCampaignVO>();

        if (getModel() instanceof FindMediaPlanCampaignVO) {
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                FindMediaPlanCampaignVO vo = new FindMediaPlanCampaignVO();

                vo.setCAMPCD(((String)result.get(Tbj12Campaign.CAMPCD.toUpperCase())));
                vo.setKENMEI(((String)result.get(Tbj12Campaign.CAMPNM.toUpperCase())));
                vo.setCODENAME((String)result.get("CODENAME"));

                // 検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }

        return list;
    }

}
