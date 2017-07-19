package jp.co.isid.ham.common.model;

import java.util.List;
import java.util.ArrayList;

import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * セキュリティ情報Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/06/11 森)<BR>
 * </P>
 * @author 森
 */
public class SecurityInfoManager
{
    /** 定数 */
    private String _allKksikognzuntcd = "*******";
    private String _defaultSetting = "0";

    /** シングルトンインスタンス */
    private static SecurityInfoManager _manager = new SecurityInfoManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private SecurityInfoManager()
    {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static SecurityInfoManager getInstance()
    {
        return _manager;
    }

    /**
     * セキュリティ情報データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public SecurityInfoResult getSecurityInfo(SecurityInfoCondition condition) throws HAMException
    {
        SecurityInfoResult result = new SecurityInfoResult();
        SecurityInfoVO vo = new SecurityInfoVO();

        if ((condition != null) &&
           (condition.getHamid() != null) &&
           (condition.getSecuritycd() != null) &&
           (condition.getUsertype() != null) &&
           (condition.getKksikognzuntcd() != null))
        {
            Mbj43SecurityItemDAO mbj43Dao = Mbj43SecurityItemDAOFactory.createMbj43SecurityItemDAO();

            Mbj43SecurityItemCondition mbj43Condition = new Mbj43SecurityItemCondition();
            mbj43Condition.setSecuritycd(condition.getSecuritycd());

            List<Mbj43SecurityItemVO> mbj43List = mbj43Dao.selectVO(mbj43Condition);

            if (mbj43List.size() == 1)
            {
                vo.setHAMID(condition.getHamid());
                vo.setSECURITYCD(condition.getSecuritycd());
                vo.setSECURITYTYPE(mbj43List.get(0).getSECURITYTYPE());
                vo.setSECURITYNM(mbj43List.get(0).getSECURITYNM());
                vo.setCHECK(_defaultSetting);    // デフォルトのセキュリティは無効
                vo.setUPDATE(_defaultSetting);   // デフォルトのセキュリティは無効
                vo.setREFERENCE(_defaultSetting);// デフォルトのセキュリティは無効

                // ユーザ毎セキュリティ設定
                Mbj42SecurityDAO mbj42Dao = Mbj42SecurityDAOFactory.createMbj42SecurityDAO();
                Mbj42SecurityCondition mbj42Condition = new Mbj42SecurityCondition();
                mbj42Condition.setHamid(condition.getHamid());
                mbj42Condition.setSecuritycd(condition.getSecuritycd());
                List<Mbj42SecurityVO> mbj42List = mbj42Dao.selectVO(mbj42Condition);

                if (mbj42List.size() == 1)
                {
                    vo.setCHECK(mbj42List.get(0).getCHECK());
                    vo.setUPDATE(mbj42List.get(0).getUPDATE());
                    vo.setREFERENCE(mbj42List.get(0).getREFERENCE());
                }
                else
                {
                    // 局コード、ユーザ種別毎セキュリティ設定
                    Mbj44SecurityBaseDAO mbj44Dao = Mbj44SecurityBaseDAOFactory.createMbj44SecurityBaseDAO();
                    Mbj44SecurityBaseCondition mbj44Condition1 = new Mbj44SecurityBaseCondition();
                    mbj44Condition1.setKksikognzuntcd(condition.getKksikognzuntcd());
                    mbj44Condition1.setUsertype(condition.getUsertype());
                    mbj44Condition1.setSecuritycd(condition.getSecuritycd());
                    List<Mbj44SecurityBaseVO> mbj44List1 = mbj44Dao.selectVO(mbj44Condition1);

                    if (mbj44List1.size() == 1)
                    {
                        vo.setCHECK(mbj44List1.get(0).getCHECK());
                        vo.setUPDATE(mbj44List1.get(0).getUPDATE());
                        vo.setREFERENCE(mbj44List1.get(0).getREFERENCE());
                    }
                    else
                    {
                        // 局コード共通、ユーザ種別毎セキュリティ設定
                        Mbj44SecurityBaseCondition mbj44Condition2 = new Mbj44SecurityBaseCondition();
                        mbj44Condition2.setKksikognzuntcd(_allKksikognzuntcd);
                        mbj44Condition2.setUsertype(condition.getUsertype());
                        mbj44Condition2.setSecuritycd(condition.getSecuritycd());
                        List<Mbj44SecurityBaseVO> mbj44List2 = mbj44Dao.selectVO(mbj44Condition2);

                        if (mbj44List2.size() == 1)
                        {
                            vo.setCHECK(mbj44List2.get(0).getCHECK());
                            vo.setUPDATE(mbj44List2.get(0).getUPDATE());
                            vo.setREFERENCE(mbj44List2.get(0).getREFERENCE());
                        }
                    }
                }

            }
        }

        List<SecurityInfoVO> voList = new ArrayList<SecurityInfoVO>();
        voList.add(vo);
        result.setSecurityInfo(voList);

        return result;

    }

}
