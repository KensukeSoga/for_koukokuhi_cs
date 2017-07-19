package jp.co.isid.ham.common.model;

import java.util.List;
import java.util.ArrayList;
import java.util.Date;
import java.util.Map;

import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * 排他チェック用DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/07 森)<BR>
 * </P>
 * @author 森
 */
public class RegistExclusionDao extends AbstractRdbDao
{
    /** 定数 */
    private String _updDate = "UPDDATE";
    private String _updId = "UPDID";

    /** チェックテーブル名 */
    private String _tableName;

    /** チェックテーブルプリフィックス */
    private String _prefix;

    /** キー */
    private String _hamId = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistExclusionDao()
    {
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
    public String[] getPrimryKeyNames()
    {
        return null;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames()
    {
        return null;
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName()
    {
        return null;
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName()
    {
        return null;
    }

    /**
     * SQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL()
    {
        String sql = "";

        if (super.getModel() instanceof RegistExclusionVO)
        {
            // MasterFormVO取得用SQL取得
            sql = getSelectSQLRegistExclusionVO();
        }
        else if (super.getModel() instanceof RegistExclusionHamIdVO)
        {
            // MasterFormVO取得用SQL取得
            sql = getSelectSQLRegistExclusionHamIdVO();
        }

        return sql;
    }

    /**
     * SELECT SQL（RegistExclusionVO）
     */
    private String getSelectSQLRegistExclusionVO()
    {
        StringBuffer selectSql = new StringBuffer();

        selectSql.append(String.format("SELECT TO_CHAR(%s.%s) AS %s ","D1","DATACOUNT","DATACOUNT"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","UPDATEDATE","UPDATEDATE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDATEUSERID","UPDATEUSERID"));
        selectSql.append(String.format("FROM "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("        SELECT COUNT(*) AS %s ","DATACOUNT"));
        selectSql.append(String.format("              ,MAX(%s.%s) AS %s ",_tableName,(_prefix + _updDate),"UPDATEDATE"));
        selectSql.append(String.format("        FROM %s ",_tableName));
        selectSql.append(String.format("     ) %s, ","D1"));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("        SELECT %s AS %s ",(_prefix + _updId),"UPDATEUSERID"));
        selectSql.append(String.format("        FROM "));
        selectSql.append(String.format("              ( "));
        selectSql.append(String.format("                 SELECT * "));
        selectSql.append(String.format("                 FROM %s ",_tableName));
        selectSql.append(String.format("                 ORDER BY %s.%s ",_tableName,(_prefix + _updId)));
        selectSql.append(String.format("              ) "));
        selectSql.append(String.format("        WHERE %s = ",(_prefix + _updDate)));
        selectSql.append(String.format("              ( "));
        selectSql.append(String.format("                SELECT MAX(%s.%s) ",_tableName,(_prefix + _updDate),"UPDATEDATE"));
        selectSql.append(String.format("                FROM %s ",_tableName));
        selectSql.append(String.format("              ) "));
        selectSql.append(String.format("        AND   ROWNUM = 1"));
        selectSql.append(String.format("     ) %s ","D2"));

        return selectSql.toString();
    };

    /**
     * SELECT SQL（RegistExclusionHamIdVO）
     */
    private String getSelectSQLRegistExclusionHamIdVO()
    {
        StringBuffer selectSql = new StringBuffer();
        StringBuffer whereSql = new StringBuffer();

        if (_hamId != null)
        {
            whereSql.append(String.format("WHERE %sHAMID = '%s' ",_prefix,_hamId));

        }
        selectSql.append(String.format("SELECT TO_CHAR(%s.%s) AS %s ","D1","DATACOUNT","DATACOUNT"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","UPDATEDATE","UPDATEDATE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDATEUSERID","UPDATEUSERID"));
        selectSql.append(String.format("FROM "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("        SELECT COUNT(*) AS %s ","DATACOUNT"));
        selectSql.append(String.format("              ,MAX(%s.%s) AS %s ",_tableName,(_prefix + _updDate),"UPDATEDATE"));
        selectSql.append(String.format("        FROM %s ",_tableName));
        selectSql.append(String.format("        %s ",whereSql.toString()));
        selectSql.append(String.format("     ) %s, ","D1"));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("        SELECT %s AS %s ",(_prefix + _updId),"UPDATEUSERID"));
        selectSql.append(String.format("        FROM "));
        selectSql.append(String.format("              ( "));
        selectSql.append(String.format("                 SELECT * "));
        selectSql.append(String.format("                 FROM %s ",_tableName));
        selectSql.append(String.format("                 ORDER BY %s.%s ",_tableName,(_prefix + _updId)));
        selectSql.append(String.format("              ) "));
        selectSql.append(String.format("        WHERE %s = ",(_prefix + _updDate)));
        selectSql.append(String.format("              ( "));
        selectSql.append(String.format("                SELECT MAX(%s.%s) ",_tableName,(_prefix + _updDate),"UPDATEDATE"));
        selectSql.append(String.format("                FROM %s ",_tableName));
        selectSql.append(String.format("                %s ",whereSql.toString()));
        selectSql.append(String.format("              ) "));
        selectSql.append(String.format("        AND   ROWNUM = 1"));
        selectSql.append(String.format("     ) %s ","D2"));

        return selectSql.toString();
    };

    /**
     * 排他チェック
     * @param exclusion 排他チェック条件
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public void checkExclusion(RegistExclusionVO exclusion,String tableName,String prefix) throws HAMException
    {
        // exclusionチェック
        if (exclusion == null)
        {   // exclusionがnullの場合は排他チェックを行わない
            return;
        }

        // パラメータチェック
        if ((tableName == null) || (prefix == null))
        {
            throw new HAMException("排他チェックエラー", "BJ-E0005");
        }

        _tableName = tableName;
        _prefix = prefix;
        super.setModel(new RegistExclusionVO());

        try
        {
            List<RegistExclusionVO> list = super.find();

            if (list.size() == 1)
            {
                RegistExclusionVO oldExclusion = list.get(0);

                if ((!oldExclusion.getDATACOUNT().equals(exclusion.getDATACOUNT())) ||
                   (!oldExclusion.getUPDATEDATE().equals(exclusion.getUPDATEDATE())) ||
                   (!oldExclusion.getUPDATEUSERID().equals(exclusion.getUPDATEUSERID())))
                {
                    throw new HAMException("排他チェックエラー", "BJ-E0005");
                }
            }
            else if (list.size() == 0)
            {   // 取得データが0件の場合
                if (!exclusion.getDATACOUNT().equals("0"))
                {
                    throw new HAMException("排他チェックエラー", "BJ-E0005");
                }
            }
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0005");
        }

    }

    /**
     * 排他チェック（HamId）
     * @param exclusion 排他チェック条件
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public void checkExclusionHamId(RegistExclusionHamIdVO exclusion,String tableName,String prefix) throws HAMException
    {
        // exclusionチェック
        if (exclusion == null)
        {   // exclusionがnullの場合は排他チェックを行わない
            return;
        }

        // パラメータチェック
        if ((tableName == null) || (prefix == null))
        {
            throw new HAMException("排他チェックエラー", "BJ-E0005");
        }

        _tableName = tableName;
        _prefix = prefix;
        _hamId = exclusion.getHAMID();
        super.setModel(new RegistExclusionHamIdVO());

        try
        {
            List<RegistExclusionHamIdVO> list = super.find();

            if (list.size() == 1)
            {
                RegistExclusionHamIdVO oldExclusion = list.get(0);

                if ((!oldExclusion.getDATACOUNT().equals(exclusion.getDATACOUNT())) ||
                   (!oldExclusion.getUPDATEDATE().equals(exclusion.getUPDATEDATE())) ||
                   (!oldExclusion.getUPDATEUSERID().equals(exclusion.getUPDATEUSERID())))
                {
                    throw new HAMException("排他チェックエラー", "BJ-E0005");
                }
            }
            else if (list.size() == 0)
            {   // 取得データが0件の場合
                if (!exclusion.getDATACOUNT().equals("0"))
                {
                    throw new HAMException("排他チェックエラー", "BJ-E0005");
                }
            }
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0005");
        }

    }

    /**
     * Modelの生成を行う<br>
     * AbstractRdbDaoのcreateFindedModelInstancesをオーバーライド<br>
     *
     * @param hashList List 検索結果
     * @return List 変換後の検索結果
     */
    @Override
    @SuppressWarnings("unchecked")
    protected List createFindedModelInstances(List hashList)
    {
        List list = null;

        if (getModel() instanceof RegistExclusionVO)
        {
            list = new ArrayList<RegistExclusionVO>();
            for (int i = 0 ; i < hashList.size() ; i++)
            {
                Map result = (Map) hashList.get(i);
                RegistExclusionVO vo = new RegistExclusionVO();

                vo.setDATACOUNT((String)result.get("DATACOUNT"));
                vo.setUPDATEDATE((Date)result.get("UPDATEDATE"));
                vo.setUPDATEUSERID((String)result.get("UPDATEUSERID"));

                list.add(vo);
            }
        }
        else if (getModel() instanceof RegistExclusionHamIdVO)
        {
            list = new ArrayList<RegistExclusionHamIdVO>();
            for (int i = 0 ; i < hashList.size() ; i++)
            {
                Map result = (Map) hashList.get(i);
                RegistExclusionHamIdVO vo = new RegistExclusionHamIdVO();

                vo.setDATACOUNT((String)result.get("DATACOUNT"));
                vo.setUPDATEDATE((Date)result.get("UPDATEDATE"));
                vo.setUPDATEUSERID((String)result.get("UPDATEUSERID"));
                vo.setHAMID(_hamId);

                list.add(vo);
            }
        }

        return list;
    }

}
