package jp.co.isid.ham.production.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.base.HAMException;

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractSearchManager {

    //�V���O���g���ϐ�
    private static ContractSearchManager _manager = new ContractSearchManager();

    /**
     * �C���X�^���X���擾���܂�
     */
    public static ContractSearchManager getInstance() {
        return _manager;
    }

    private ContractSearchManager() {

    }

    /**
     * �_������������A���ʂ��擾���܂�
     * @param cond
     * @return
     * @throws HAMException
     */
    public ContractSearchResult getContractListByCondition(ContractSearchCondition cond)
            throws HAMException {

        ContractSearchResult result = new ContractSearchResult();

        ContractSearchDAO dao = ContractSearchDAOFactory.createContractListDao();

        //�_������������A���ʂ��擾
        List<ContractSearchVO> list = dao.findContoractListByCondition(cond);
        result.setCntrctList(list);

        return result;
    }


}
