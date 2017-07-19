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
 * �Ԏ�}�X�^�擾DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/03/27 T.Hadate)<BR>
 * </P>
 *
 * @author Takahiro Hadate
 */
public class FindCarListDAO extends AbstractRdbDao {

    /** �f�[�^�������� */
    private FindCarListCondition _cond;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindCarListDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[���擾����
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �e�[�u���񖼂��擾����
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
     * �e�[�u���񖼂��擾����
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        return createSql();
    }

    /**
     * SQL���쐬����.
     *
     * @return SQL
     */
    private String createSql() {

        StringBuilder sb = new StringBuilder();

        sb.append("SELECT");
        //�S���ڂ��擾
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
     * �Ԏ�ꗗ�̌������s��.
     *
     * @param cond ��������
     * @return ��������
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
     * Model�̐������s��<br>
     * �������ʂ�VO��KEY���啶���̂��ߕϊ��������s��<br>
     * AbstractRdbDao��createFindedModelInstances���I�[�o�[���C�h<br>
     *
     * @param hashList
     *            List ��������
     * @return List<FindJissiNoCntCondVO> �ϊ���̌�������
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

                //�������ʒ���̏�Ԃɂ���
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }

        return list;
    }

}
