package jp.co.isid.ham.common.model;

import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;

import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * 機能制御情報Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/06/11 森)<BR>
 * </P>
 * @author 森
 */
public class FunctionControlInfoManager
{
    /** 定数 */
    private String _allKksikognzuntcd = "*******";

    /** シングルトンインスタンス */
    private static FunctionControlInfoManager _manager = new FunctionControlInfoManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FunctionControlInfoManager()
    {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FunctionControlInfoManager getInstance()
    {
        return _manager;
    }

    /**
     * 機能制御情報データVO取得
     *
     * @return 検索データVO
     * @param condition 検索条件
     */
    public FunctionControlInfoResult getFunctionControlInfo(FunctionControlInfoCondition condition) throws HAMException
    {
        FunctionControlInfoResult result = new FunctionControlInfoResult();
        Map<String,FunctionControlInfoVO> voMap = new HashMap<String,FunctionControlInfoVO>();
        Map<String,String> defaultControlMap = new HashMap<String,String>();

        if ((condition != null) &&
           (condition.getHamid() != null) &&
           ((condition.getFunctype() != null) || (condition.getFormid() != null)) &&
           (condition.getUsertype() != null) &&
           (condition.getKksikognzuntcd() != null))
        {
            Mbj34FunctionControlItemDAO mbj34Dao = Mbj34FunctionControlItemDAOFactory.createMbj34FunctionControlItemDAO();

            Mbj34FunctionControlItemCondition mbj34Condition = new Mbj34FunctionControlItemCondition();
            mbj34Condition.setFunctype(condition.getFunctype());
            mbj34Condition.setFormid(condition.getFormid());

            List<Mbj34FunctionControlItemVO> mbj34List = mbj34Dao.selectVO(mbj34Condition);

            if (mbj34List.size() > 0)
            {
                for (int i = 0 ; i < mbj34List.size() ; i++)
                {
                    FunctionControlInfoVO vo = new FunctionControlInfoVO();

                    vo.setHAMID(condition.getHamid());
                    vo.setFORMID(mbj34List.get(i).getFORMID());
                    vo.setFUNCCD(mbj34List.get(i).getFUNCCD());
                    vo.setFUNCTYPE(mbj34List.get(i).getFUNCTYPE());
                    vo.setFUNCNM(mbj34List.get(i).getFUNCNM());
                    vo.setOBJNAME(mbj34List.get(i).getOBJNAME());
                    vo.setSORTNO(mbj34List.get(i).getSORTNO());

                    String funcCd = vo.getFUNCCD();
                    voMap.put(funcCd,vo);
                    defaultControlMap.put(funcCd,mbj34List.get(i).getDEFAULTCONTROL());
                }

                // ユーザ毎機能制御設定
                Mbj33FunctionControlDAO mbj33Dao = Mbj33FunctionControlDAOFactory.createMbj33FunctionControlDAO();
                Mbj33FunctionControlCondition mbj33Condition = new Mbj33FunctionControlCondition();
                mbj33Condition.setHamid(condition.getHamid());
                List<Mbj33FunctionControlVO> mbj33List = mbj33Dao.selectVO(mbj33Condition);

                for (int i = 0 ; i < mbj33List.size() ; i++)
                {
                    if (voMap.containsKey(mbj33List.get(i).getFUNCCD()))
                    {
                        FunctionControlInfoVO voTmp = voMap.get(mbj33List.get(i).getFUNCCD());
                        if (voTmp.getCONTROL() == null)
                        {
                            voTmp.setCONTROL(mbj33List.get(i).getCONTROL());
                            voMap.put(voTmp.getFUNCCD(),voTmp);
                        }
                    }
                }

                Mbj39FunctionControlBaseDAO mbj39Dao = Mbj39FunctionControlBaseDAOFactory.createMbj39FunctionControlBaseDAO();

                // 局コード、ユーザ種別毎機能制御設定
                Mbj39FunctionControlBaseCondition mbj39Condition1 = new Mbj39FunctionControlBaseCondition();
                mbj39Condition1.setKksikognzuntcd(condition.getKksikognzuntcd());
                mbj39Condition1.setUsertype(condition.getUsertype());
                List<Mbj39FunctionControlBaseVO> mbj39List1 = mbj39Dao.selectVO(mbj39Condition1);

                for (int i = 0 ; i < mbj39List1.size() ; i++)
                {
                    if (voMap.containsKey(mbj39List1.get(i).getFUNCCD()))
                    {
                        FunctionControlInfoVO voTmp = voMap.get(mbj39List1.get(i).getFUNCCD());
                        if (voTmp.getCONTROL() == null)
                        {
                            voTmp.setCONTROL(mbj39List1.get(i).getCONTROL());
                            voMap.put(voTmp.getFUNCCD(),voTmp);
                        }
                    }
                }

                // 局コード共通、ユーザ種別毎機能制御設定
                Mbj39FunctionControlBaseCondition mbj39Condition2 = new Mbj39FunctionControlBaseCondition();
                mbj39Condition2.setKksikognzuntcd(_allKksikognzuntcd);
                mbj39Condition2.setUsertype(condition.getUsertype());
                List<Mbj39FunctionControlBaseVO> mbj39List2 = mbj39Dao.selectVO(mbj39Condition2);

                for (int i = 0 ; i < mbj39List2.size() ; i++)
                {
                    if (voMap.containsKey(mbj39List2.get(i).getFUNCCD()))
                    {
                        FunctionControlInfoVO voTmp = voMap.get(mbj39List2.get(i).getFUNCCD());
                        if (voTmp.getCONTROL() == null)
                        {
                            voTmp.setCONTROL(mbj39List2.get(i).getCONTROL());
                            voMap.put(voTmp.getFUNCCD(),voTmp);
                        }
                    }
                }
            }
        }

        List<FunctionControlInfoVO> voList = new ArrayList<FunctionControlInfoVO>();
        Set<String> keyset = voMap.keySet();
        Iterator<String> it = keyset.iterator();

        while(it.hasNext())
        {
            Object key = it.next();
            FunctionControlInfoVO voTmp = voMap.get(key);

            if (voTmp.getCONTROL() == null)
            {
                voTmp.setCONTROL(defaultControlMap.get(key));
            }

            voList.add(voTmp);
        }

        result.setFunctionControlInfo(voList);

        return result;

    }

}
