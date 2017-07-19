package jp.co.isid.ham.production.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.base.HAMException;

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractSearchManager {

    //シングルトン変数
    private static ContractSearchManager _manager = new ContractSearchManager();

    /**
     * インスタンスを取得します
     */
    public static ContractSearchManager getInstance() {
        return _manager;
    }

    private ContractSearchManager() {

    }

    /**
     * 契約情報を検索し、結果を取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    public ContractSearchResult getContractListByCondition(ContractSearchCondition cond)
            throws HAMException {

        ContractSearchResult result = new ContractSearchResult();

        ContractSearchDAO dao = ContractSearchDAOFactory.createContractListDao();

        //契約情報を検索し、結果を取得
        List<ContractSearchVO> list = dao.findContoractListByCondition(cond);
        result.setCntrctList(list);

        return result;
    }


}
